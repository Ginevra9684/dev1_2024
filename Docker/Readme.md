per utilizzare un file esterno dalla cartella bin
aggiungere al docker file 
RUN touch tentativi.json && chmod 777 tentativi.json

in console
docker volume create tentativi_volume
docker run -v tentativi_volume:/app -it docker
docker images
docker save -o indovina-numero.tar docker:latest
docker load -i indovina-numero.tar