<h2>Docker exercises</h2>

This is an extremely simple test project, the goal of the exercise is to put it in containers.
<br>
It uses an environmental variable set in the Dockerfile with ENV (to be researched: a safer place for more important secrets), this can be overwritten when one starts the container with -e.

On <strong>Docker Hub</strong>, it's <a href=https://cloud.docker.com/repository/docker/gagyizsofi/first_app>here</a>. 
The <strong>Windows</strong> version is tagged "one", the <strong>Linux</strong> version is tagged "linux".

It can be run, for example, with "docker run -p 8000:80 -e flower="violet" --name test_container gagyizsofi/first_app:one".
