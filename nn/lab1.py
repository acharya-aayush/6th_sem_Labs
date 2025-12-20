import numpy as np
import matplotlib.pyplot as plt

class SimpleNeuron:
    def __init__(self, n_in, mode='sigmoid'):
        self.w = np.random.randn(n_in) * 0.5
        self.b = np.random.rand() * 0.5
        self.mode = mode

    def activate(self, x):
        if self.mode == 'sigmoid':
            return 1 / (1 + np.exp(-np.clip(x, -250, 250)))
        elif self.mode == 'tanh':
            return np.tanh(x)
        elif self.mode == 'relu':
            return np.maximum(0, x)
        return x

    def forward(self, x):
        z = np.dot(x, self.w) + self.b
        return self.activate(z)

class NeuralNet:
    def __init__(self, n_in, n_hid, n_out):
        self.w1 = np.random.randn(n_in, n_hid) * 0.5
        self.b1 = np.zeros((1, n_hid))
        self.w2 = np.random.randn(n_hid, n_out) * 0.5
        self.b2 = np.zeros((1, n_out))

    def run(self, x):
        h_out = 1 / (1 + np.exp(-np.clip(np.dot(x, self.w1) + self.b1, -250, 250)))
        y_out = 1 / (1 + np.exp(-np.clip(np.dot(h_out, self.w2) + self.b2, -250, 250)))
        return y_out

def plot_functions():
    x = np.linspace(-5, 5, 100)
    funcs = [1/(1+np.exp(-x)), np.tanh(x), np.maximum(0, x)]
    names = ["Sigmoid", "Tanh", "ReLU"]
    
    plt.figure(figsize=(12, 3))
    for i in range(3):
        plt.subplot(1, 3, i+1)
        plt.plot(x, funcs[i], linewidth=2)
        plt.title(names[i])
        plt.grid(True)
    plt.show()

node = SimpleNeuron(3, mode='sigmoid')
print(f"Neuron Output: {node.forward(np.array([0.5, -0.2, 0.8])):.4f}")

net = NeuralNet(2, 4, 1)
print(f"Network Shape: {net.run(np.random.randn(5, 2)).shape}")
plot_functions()  
