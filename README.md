<h2>Docker + RabbitMQ exercises</h2>

These are very simple ASP.NET apps - the challenge was to run them from (connected) containers.

<h3>Single container</h3>

The app uses an environmental variable set in the Dockerfile using ENV (to be researched: a safer place for more important secrets), which can be overwritten when one starts the container with the -e command.

On <strong>Docker Hub</strong>, it's <a href=https://cloud.docker.com/repository/docker/gagyizsofi/first_app>here</a>. 
The <strong>Windows</strong> version is tagged "one", the <strong>Linux</strong> version is tagged "linux".

They can be run
- with Docker, for example "docker run -p 8000:80 -e flower="violet" --name test_container gagyizsofi/first_app:linux"
- with Docker Compose, using <a href=https://github.com/zsofi-gagyi/dockerExercises/blob/linux/docker-compose.yml>my first YAML file</a> (it will also run at localhost:8000).

<h3>Two containers</h3>

The "producer" app at localhost:8001 counts the visitors arriving at the site, and notifies the "consumer" app about them, which shows these logs at localhost:8000. Both run in linux containers, and communicate with each other over HTTP.

On <strong>Docker Hub</strong>, it's <a href=https://cloud.docker.com/repository/docker/gagyizsofi/multiple_containers>here</a>. 

They can be run with Docker Compose, using <a href=https://github.com/zsofi-gagyi/dockerExercises/blob/master/MultipleContainers/docker-compose.yaml>this YAML file</a>.

<h3>Two containers with RabbitMQ, producer-consumer model*</h3>

The "producer" app at localhost:8001 counts the visitors arriving at the site, and notifies about them the RabbitMQ instance, which in turn forwards this information to the "consumer" app. The consumer's logs can be seen at localhost:8000. All components run in linux containers, and the C# components communicate with the RabbitMQ module using the RabbitMQ.Client NuGet package (over the AMQP protocol).

On <strong>Docker Hub</strong>, it's <a href=https://cloud.docker.com/repository/registry-1.docker.io/gagyizsofi/two_containers_with_rabbit>here</a>. 

They can be run with Docker Compose, using <a href=https://github.com/zsofi-gagyi/dockerExercises/blob/master/WithRabbitMQ/docker-compose.yaml>this YAML file</a>.
