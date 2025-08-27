import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation

# Dataset: Girls (+1) | Boys (-1)
# Features: [Hair Length, Voice Pitch]
X = np.array([
    [9, 6],     # girl (long hair, high pitch)
    [8, 5.5],   # girl
    [1, 2],     # boy (short hair, low pitch)
    [2, 1],     # boy
    [7, 6],     # girl
    [2, 2],     # boy
    [8.5, 5.5], # girl
])
d = np.array([1, 1, -1, -1, 1, -1, 1])  # desired outputs: +1 for girls, -1 for boys

# Add bias input (x0 = 1)
X_bias = np.hstack((np.ones((X.shape[0], 1)), X))

# Initial weights and learning rate
eta = 1.0
w = np.zeros(X_bias.shape[1])
history = []  # to store (weights, current index, equation text, epoch, status)

def predict(x):
    return np.sign(np.dot(w, x))

def train():
    global w
    converged = False
    epoch = 0
    
    print("Starting Perceptron Training...")
    print("Dataset: Hair Length vs Voice Pitch for Gender Classification")
    print("Girls: +1 (blue), Boys: -1 (red)")
    print("=" * 60)
    
    while not converged:
        epoch += 1
        converged = True
        print(f"\n--- EPOCH {epoch} ---")
        
        for i, (xi, target) in enumerate(zip(X_bias, d)):
            net = np.dot(w, xi)
            y = np.sign(net) if net != 0 else 0
            
            gender = "Girl" if target == 1 else "Boy"
            prediction = "Girl" if y == 1 else "Boy" if y == -1 else "Unknown"
            
            if y != target:
                old_w = w.copy()
                w += eta * target * xi
                
                equation = (
                    f"EPOCH {epoch} - POINT {i+1} ({gender}): MISTAKE!\n"
                    f"Input: {xi.round(2)} | Net: {net:.2f} | Predicted: {prediction} | Actual: {gender}\n"
                    f"\nWeight Update Rule: w_new = w_old + eta * target * input\n"
                    f"w_new = {old_w.round(2)} + {eta} * {target} * {xi.round(2)}\n"
                    f"w_new = {w.round(2)}\n"
                    f"\nDecision Boundary: {w[0]:.2f} + {w[1]:.2f}*x1 + {w[2]:.2f}*x2 = 0"
                )
                history.append((w.copy(), i, equation, epoch, "mistake"))
                converged = False
                print(f"Point {i+1} ({gender}): MISTAKE - Weights updated to {w.round(2)}")
            else:
                equation = (
                    f"EPOCH {epoch} - POINT {i+1} ({gender}): CORRECT!\n"
                    f"Input: {xi.round(2)} | Net: {net:.2f} | Predicted: {prediction} | Actual: {gender}\n"
                    f"\nNo weight update needed (correct prediction)\n"
                    f"Current weights: {w.round(2)}\n"
                    f"\nDecision Boundary: {w[0]:.2f} + {w[1]:.2f}*x1 + {w[2]:.2f}*x2 = 0"
                )
                history.append((w.copy(), i, equation, epoch, "correct"))
                print(f"Point {i+1} ({gender}): CORRECT - No update needed")
    
    print(f"\n" + "=" * 60)
    print(f"TRAINING COMPLETED!")
    print(f"Converged after {epoch} epochs")
    print(f"Final weights: {w.round(3)}")
    print(f"Final decision boundary: {w[0]:.2f} + {w[1]:.2f}*x1 + {w[2]:.2f}*x2 = 0")
    
    # Add final summary to history
    final_equation = (
        f"TRAINING COMPLETED SUCCESSFULLY!\n\n"
        f"Final Decision Boundary:\n"
        f"{w[0]:.2f} + {w[1]:.2f}*Hair_Length + {w[2]:.2f}*Voice_Pitch = 0\n\n"
        f"Classification Rule:\n"
        f"If result > 0: Classify as Girl\n"
        f"If result < 0: Classify as Boy\n\n"
        f"Total epochs needed: {epoch}\n"
        f"All points correctly classified!"
    )
    history.append((w.copy(), -1, final_equation, epoch, "converged"))

# Train the perceptron
train()

# Enhanced Visualization Setup
plt.style.use('seaborn-v0_8')
fig, (ax1, ax2) = plt.subplots(1, 2, figsize=(18, 9))
fig.suptitle('Perceptron Learning Algorithm: Real-time Visualization', fontsize=16, fontweight='bold')

# Left plot: Main visualization
colors = ['blue' if label == 1 else 'red' for label in d]
ax1.scatter(X[:, 0], X[:, 1], c=colors, s=120, edgecolors='black', alpha=0.8, linewidths=2)

# Add labels for each point
labels = ['Girl', 'Girl', 'Boy', 'Boy', 'Girl', 'Boy', 'Girl']
for i, (point, label) in enumerate(zip(X, labels)):
    ax1.annotate(f'{label} {i+1}\n({point[0]}, {point[1]})', 
                (point[0], point[1]), xytext=(10, 10), 
                textcoords='offset points', fontsize=10, ha='left',
                bbox=dict(boxstyle="round,pad=0.3", facecolor='white', alpha=0.8))

ax1.set_xlim(-1, 12)
ax1.set_ylim(-1, 8)
ax1.set_xlabel('Hair Length (arbitrary units)', fontsize=12, fontweight='bold')
ax1.set_ylabel('Voice Pitch (arbitrary units)', fontsize=12, fontweight='bold')
ax1.set_title("Gender Classification Dataset", fontsize=14, fontweight='bold')
ax1.grid(True, alpha=0.4)

# Add legend
from matplotlib.patches import Patch
legend_elements = [
    Patch(facecolor='blue', edgecolor='black', label='Girls (+1)'),
    Patch(facecolor='red', edgecolor='black', label='Boys (-1)'),
    plt.Line2D([0], [0], marker='*', color='w', markerfacecolor='lime', 
              markersize=15, label='Correct Prediction', markeredgecolor='black'),
    plt.Line2D([0], [0], marker='*', color='w', markerfacecolor='orange', 
              markersize=15, label='Mistake (Update)', markeredgecolor='black'),
    plt.Line2D([0], [0], color='green', linewidth=3, linestyle='--', label='Decision Boundary')
]
ax1.legend(handles=legend_elements, loc='upper left', fontsize=10)

# Decision boundary line
line, = ax1.plot([], [], 'g--', lw=4, alpha=0.8)

# Right plot: Information display
ax2.axis('off')
ax2.set_xlim(0, 1)
ax2.set_ylim(0, 1)

# Text boxes for different information
equation_box = ax2.text(0.05, 0.95, '', fontsize=10, verticalalignment='top',
                       bbox=dict(boxstyle="round,pad=0.5", facecolor='lightblue', alpha=0.9),
                       family='monospace', wrap=True)

status_box = ax2.text(0.05, 0.35, '', fontsize=11, verticalalignment='top',
                     bbox=dict(boxstyle="round,pad=0.5", facecolor='lightgreen', alpha=0.9),
                     fontweight='bold')

weights_box = ax2.text(0.05, 0.05, '', fontsize=11, verticalalignment='bottom',
                      bbox=dict(boxstyle="round,pad=0.5", facecolor='lightyellow', alpha=0.9),
                      fontweight='bold')

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

    # Clear existing highlighted points
    for collection in ax1.collections[:]:
        if collection.get_sizes().size > 0 and collection.get_sizes()[0] > 200:  # Remove only highlight points
            collection.remove()
    
    # Highlight the current point being evaluated (if not converged)
    if idx >= 0:
        if status == 'correct':
            point_color = 'lime'
            marker_size = 300
        elif status == 'mistake':
            point_color = 'orange'
            marker_size = 350
        else:
            point_color = 'yellow'
            marker_size = 250
            
        ax1.scatter(X[idx, 0], X[idx, 1], c=point_color, s=marker_size, marker='*', 
                   edgecolors='black', linewidths=4, zorder=10)

    # Update decision boundary line
    line.set_data(x_vals, y_vals)
    
    # Update text displays
    equation_box.set_text(eq_text)
    
    # Status information
    if status == 'mistake':
        status_text = "STATUS: MISTAKE DETECTED!\nWeights are being updated...\nDecision boundary will move"
        status_color = 'lightcoral'
    elif status == 'correct':
        status_text = "STATUS: CORRECT PREDICTION!\nNo weight update needed\nDecision boundary stays"
        status_color = 'lightgreen'
    elif status == 'converged':
        status_text = "STATUS: TRAINING COMPLETED!\nPerceptron has converged\nAll points correctly classified"
        status_color = 'gold'
    else:
        status_text = "STATUS: Training in progress...\nEvaluating data points"
        status_color = 'lightblue'
    
    status_box.set_text(status_text)
    status_box.set_bbox(dict(boxstyle="round,pad=0.5", facecolor=status_color, alpha=0.9))
    
    # Current weights display
    weights_text = (f"CURRENT WEIGHTS:\n"
                   f"w0 (bias)      = {w[0]:6.2f}\n"
                   f"w1 (hair)      = {w[1]:6.2f}\n"
                   f"w2 (voice)     = {w[2]:6.2f}\n\n"
                   f"EQUATION:\n"
                   f"{w[0]:.1f} + {w[1]:.1f}*x1 + {w[2]:.1f}*x2 = 0")
    weights_box.set_text(weights_text)
    
    return line, equation_box, status_box, weights_box

# Create and run animation
print("\nStarting visualization...")
print("Watch how the decision boundary (green dashed line) moves as the perceptron learns!")
print("Orange stars = mistakes that trigger weight updates")
print("Green stars = correct predictions")

ani = FuncAnimation(fig, update, frames=len(history)+3, interval=2000, repeat=True, blit=False)
plt.tight_layout()
plt.show()

# Uncomment to save as GIF
# print("Saving animation as GIF...")
# ani.save('perceptron_learning.gif', writer='pillow', fps=0.5, dpi=100)
# print("Animation saved as 'perceptron_learning.gif'")
