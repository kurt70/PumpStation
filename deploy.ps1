Param(
    [string]$buildnumber
)
docker login
docker build -t kurtmonge/pumpstation:$buildnumber .
docker push kurtmonge/pumpstation:$buildnumber
Echo "Use the following on the host system:"
Echo "docker pull kurtmonge/pumpstation:$buildnumber"
Echo "docker run -p 8888:5000 kurtmonge/pumpstation:$buildnumber"