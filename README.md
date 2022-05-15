# SellingHalid_MicroServiceArchitecture
## Description
SellingHalid project is a Microservice project. Project purpose is Selling stuff application.
Here is the project link: http://20.113.66.240:2000/ .


<h3> Here is the project visiualiton. </h3>
</br>
<img src="https://docs.microsoft.com/tr-tr/dotnet/architecture/microservices/multi-container-microservice-net-applications/media/microservice-application-design/eshoponcontainers-reference-application-architecture.png"/>
</br>

I developed this project with microservice architecture.
</br>

I used all tools as you can see on image while developing this project.
</br>

I implement Ocelet in Apigateway for routing services.
</br>

For service registeration (or Service discovery), I used the Consul. Published with Docker container.
</br>

I holds basket items in Redis which is a cache database.
</br>

I used Serilog and Graylog for logging.
</br>

There are two EventBus for comminicated among services. RabbitMQ and AzureService.
</br>

Microsoft Sql used for hold information in database.
</br>

I used onion arthitecture in Order Service.
</br>

For publish these tools, I used Docker in Azure VM.
</br>

For client side, I just implement Blazor as webapp.

</br>
During the project I used CI/CD.


