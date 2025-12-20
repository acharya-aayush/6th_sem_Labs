import subprocess
import sys
import os

# Create venv if not exists
def create_venv():
    if not os.path.exists('venv'):
        subprocess.check_call([sys.executable, '-m', 'venv', 'venv'])
        print('Virtual environment created.')
    else:
        print('Virtual environment already exists.')

# Activate venv and install requirements
def install_requirements():
    if os.name == 'nt':
        activate = os.path.join('venv', 'Scripts', 'activate.bat')
        command = f'"{activate}" && pip install -r requirements.txt'
        subprocess.call(command, shell=True)
    else:
        activate = os.path.join('venv', 'bin', 'activate')
        command = f'source "{activate}" && pip install -r requirements.txt'
        subprocess.call(command, shell=True)

if __name__ == '__main__':
    create_venv()
    install_requirements()
    print('Setup complete!')
