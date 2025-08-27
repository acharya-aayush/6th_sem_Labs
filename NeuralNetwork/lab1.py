x_input = [0.1, 0.3, 0.5]
weight = [0.4, 0.3, 0.6]

def step(wt_sum):
    threshold = 0.5
    if wt_sum > threshold:
        return 1
    else:
        return -1

def perceptron(x_input, weight):
    wt_sum = 0
    for x, w in zip(x_input, weight):
        wt_sum += x * w
    print("Weighted Sum:", wt_sum)
    return step(wt_sum)

output = perceptron(x_input, weight)
print("Output:", output)