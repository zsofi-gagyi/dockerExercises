<h2>Docker exercises</h2>

This is an extremely simple test project, the goal of the exercise is to put it in containers.
<br>
It uses an environmental variable set in the Dockerfile with ENV - to be researched a safer way for more important secrets.

The Windows version, on Docker Hub, is <a href=https://cloud.docker.com/repository/docker/gagyizsofi/first_app>here</a>; it can be run, for example, with "docker run -p 8000:80 --name test_container gagyizsofi/first_app:one".