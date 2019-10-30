<h2>Docker exercises</h2>

This is an extremely simple web app, the goal of the exercise is to put it in containers.
<br>
It uses an environmental variable set in the Dockerfile using ENV (to be researched: a safer place for more important secrets), this can be overwritten when one starts the container with the -e command.

On <strong>Docker Hub</strong>, it's <a href=https://cloud.docker.com/repository/docker/gagyizsofi/first_app>here</a>. 
The <strong>Windows</strong> version is tagged "one", the <strong>Linux</strong> version is tagged "linux".

They can be run
- with Docker, for example "docker run -p 8000:80 -e flower="violet" --name test_container gagyizsofi/first_app:linux"
- with Docker Compose, using <a href=https://github.com/zsofi-gagyi/dockerExercises/blob/linux/docker-compose.yml>my first YAML file</a>.
