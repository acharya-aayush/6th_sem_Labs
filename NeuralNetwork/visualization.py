import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# 👩‍💼 Girls (+1) | 👨‍💼 Boys (-1)
X = np.array([
    [9, 6],   # girl (long hair, high pitch)
    [8, 5.5], # girl
    [1, 2],   # boy (short hair, low pitch)
    [2, 1],   # boy
    [7, 6],   # girl
    [2, 2],   # boy
    [8.5, 5.5], # girl
])
d = np.array([1, 1, -1, -1, 1, -1, 1])  # desired outputs

# Add bias input (x0 = 1)
X_bias = np.hstack((np.ones((X.shape[0], 1)), X))

# Initial weights and learning rate
eta = 1.0
w = np.zeros(X_bias.shape[1])
history = []  # to store (weights, current index, equation text)

def predict(x):
    return np.sign(np.dot(w, x))

def train():
    global w
    converged = False
    epoch = 0
    while not converged:
        epoch += 1
        converged = True
        print(f"\n--- Epoch {epoch} ---")
        for i, (xi, target) in enumerate(zip(X_bias, d)):
            net = np.dot(w, xi)
            y = np.sign(net) if net != 0 else 0
            
            if y != target:
                old_w = w.copy()
                w += eta * target * xi
                equation = (
                    f"Epoch {epoch}, Point {i+1}: MISTAKE!\n"
                    f"Net = {net:.2f}, Output = {int(y)}, Target = {target}\n"
                    f"w_new = {old_w.round(2)} + {eta} × {target} × {xi.round(2)}\n"
                    f"w_new = {w.round(2)}"
                )
                history.append((w.copy(), i, equation, epoch, "mistake"))
                converged = False
                print(f"Point {i+1}: MISTAKE - Updated weights to {w.round(2)}")
            else:
                equation = (
                    f"Epoch {epoch}, Point {i+1}: CORRECT ✓\n"
                    f"Net = {net:.2f}, Output = {int(y)}, Target = {target}\n"
                    f"No weight update needed\n"
                    f"w = {w.round(2)}"
                )
                history.append((w.copy(), i, equation, epoch, "correct"))
                print(f"Point {i+1}: CORRECT - No update needed")
    
    print(f"\nConverged after {epoch} epochs!")
    print(f"Final weights: {w.round(2)}")
    
    # Add final summary
    final_equation = (
        f"🎉 CONVERGED! 🎉\n"
        f"Final decision boundary:\n"
        f"{w[0]:.2f} + {w[1]:.2f}x₁ + {w[2]:.2f}x₂ = 0\n"
        f"Training completed in {epoch} epochs"
    )
    history.append((w.copy(), -1, final_equation, epoch, "converged"))

train()

# 🎨 Enhanced Visualization setup
fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(16, 8))

# Left plot: Main visualization
colors = ['blue' if label == 1 else 'red' for label in d]
ax1.scatter(X[:, 0], X[:, 1], c=colors, s=100, edgecolors='k', alpha=0.7)

# Add labels for points
labels = ['Girl', 'Girl', 'Boy', 'Boy', 'Girl', 'Boy', 'Girl']
for i, (point, label) in enumerate(zip(X, labels)):
    ax1.annotate(f'{label}\n({point[0]}, {point[1]})', 
                (point[0], point[1]), xytext=(5, 5), 
                textcoords='offset points', fontsize=9, ha='left')

ax1.set_xlim(-1, 12)
ax1.set_ylim(-1, 8)
ax1.set_xlabel('Hair Length', fontsize=12)
ax1.set_ylabel('Voice Pitch', fontsize=12)
ax1.set_title("Perceptron Learning: Girls 👩 vs Boys 👨", fontsize=14, fontweight='bold')
ax1.grid(True, alpha=0.3)

# Add legend
from matplotlib.patches import Patch
legend_elements = [Patch(facecolor='blue', label='Girls (+1)'),
                  Patch(facecolor='red', label='Boys (-1)'),
                  plt.Line2D([0], [0], marker='*', color='w', markerfacecolor='yellow', 
                            markersize=15, label='Current Point', markeredgecolor='black')]
ax1.legend(handles=legend_elements, loc='upper left')

line, = ax1.plot([], [], 'g--', lw=3, label='Decision Boundary')

# Right plot: Equation and status display
ax2.axis('off')
ax2.set_xlim(0, 1)
ax2.set_ylim(0, 1)

# Text boxes for different information
equation_box = ax2.text(0.05, 0.85, '', fontsize=11, verticalalignment='top',
                       bbox=dict(boxstyle="round,pad=0.5", facecolor='lightblue', alpha=0.8),
                       family='monospace')

status_box = ax2.text(0.05, 0.45, '', fontsize=10, verticalalignment='top',
                     bbox=dict(boxstyle="round,pad=0.5", facecolor='lightgreen', alpha=0.8))

weights_box = ax2.text(0.05, 0.05, '', fontsize=10, verticalalignment='bottom',
                      bbox=dict(boxstyle="round,pad=0.5", facecolor='lightyellow', alpha=0.8))

def update(frame):
    if frame >= len(history):
        return line, equation_box, status_box, weights_box

    w, idx, eq_text, epoch, status = history[frame]
    x_vals = np.array(ax1.get_xlim())

    # Calculate decision boundary
    if w[2] == 0:
        y_vals = np.zeros_like(x_vals)
    else:
        y_vals = -(w[0] + w[1]*x_vals) / w[2]

    # Clear existing scatter plots
    for collection in ax1.collections[:]:
        collection.remove()
    
    # Plot all points with colors
    colors = ['blue' if label == 1 else 'red' for label in d]
    ax1.scatter(X[:, 0], X[:, 1], c=colors, s=100, edgecolors='k', alpha=0.7)
    
    # Highlight the current point being evaluated (if not converged)
    if idx >= 0:
        point_color = 'lime' if status == 'correct' else 'orange' if status == 'mistake' else 'yellow'
        ax1.scatter(X[idx, 0], X[idx, 1], c=point_color, s=250, marker='*', 
                   edgecolors='black', linewidths=3, zorder=5)

    # Update decision boundary line
    line.set_data(x_vals, y_vals)
    
    # Update text displays
    equation_box.set_text(eq_text)
    
    # Status information
    if status == 'mistake':
        status_text = "❌ MISTAKE DETECTED!\nWeights will be updated"
        status_color = 'lightcoral'
    elif status == 'correct':
        status_text = "✅ CORRECT PREDICTION!\nNo update needed"
        status_color = 'lightgreen'
    elif status == 'converged':
        status_text = "🎉 TRAINING COMPLETED!\nPerceptron has converged"
        status_color = 'gold'
    else:
        status_text = "🔄 Training in progress..."
        status_color = 'lightblue'
    
    status_box.set_text(status_text)
    status_box.set_bbox(dict(boxstyle="round,pad=0.5", facecolor=status_color, alpha=0.8))
    
    # Current weights display
    weights_text = f"Current Weights:\nw₀ (bias) = {w[0]:.2f}\nw₁ (hair) = {w[1]:.2f}\nw₂ (pitch) = {w[2]:.2f}"
    weights_box.set_text(weights_text)
    
    return line, equation_box, status_box, weights_box

ani = FuncAnimation(fig, update, frames=len(history)+5, interval=1500, repeat=True, blit=False)
plt.tight_layout()
plt.show()

# Optional: Save animation as GIF
# ani.save('perceptron_learning.gif', writer='pillow', fps=1)
