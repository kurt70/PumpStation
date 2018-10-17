docker build -t kurtmonge/pumpstation:4 .
docker push kurtmonge/pumpstation:4
Echo "Use the following on the host system:"
Echo "docker pull kurtmonge/pumpstation:4"
Echo "docker run -p 8888:5000 kurtmonge/pumpstation:4"