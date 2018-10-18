Param(
    [string]$buildNumber
)
docker build -t kurtmonge/pumpstation:$buildNumber .
docker push kurtmonge/pumpstation:$buildNumber
Echo "Use the following on the host system:"
Echo "docker pull kurtmonge/pumpstation:$buildNumber"
Echo "docker run -p 8888:5000 kurtmonge/pumpstation:$buildNumber"