# Vortx


## Simulador de Custo de Chamadas à Longa Distância

Este projeto consiste em prover um Simulador do Custo de Chamadas de Longa Distância para os Clientes da VxTel.

Escopo (MVP)
* Controlar cadastro de tarifas
* Controlar cadastro de produtos
* Realizar simulação do valor de chamada

Fora do Escopo
* Controlar acesso a API
* Controlar acesso ao Site
* Controlar cadastro de clientes
* Controlar contratação de produtos pelo cliente
* Controlar chamadas realizadas pelo cliente
* Controlar consumo do cliente
* Controlar conta de cliente
* Validar dados que estão sendo manipulados


## Como executar o projeto

O projeto é composto por 2 aplicações, uma API e um Site.

A primeria aplicação é uma API, esta API é responsável por gerenciar todas as regras de negócio e realizar as integrações com banco de dados.

A segunda aplicação é um Site, este é responsável por criar uma interface amigável para que o usuário possa interagir com as funcionalidades mapeadas acima.

A documentação utilizada no desenvolvimento foi disponibilidade no diretório "desenho_solucao" deste repositório.

As aplicações foram desenvolvidas utilizando a arquitetura de microserviço possibilitando a implantação em Cloud pública, privada ou até mesmo em containers locais com o apoio do Docker.

Como recurso auxiliar, foi disponibilizado um arquivo do Docker-Compose para facilitar a execução das aplicações em ambiente local para fim de testes.
Este arquivo e o script de configuração do banco de dados foram disponibilizados no diretório "docker_compose" deste repositório.

Caso necessite instalar o Docker, recomendo seguir as instruções do fabricante da plataforma. https://docs.docker.com/get-docker/

O código fonte das aplicações foram disponibilizados no diretório "src" deste repositório.


## Tecnologias utilizadas

* C# .Net Core 6.0
* MySql 8.0
* EntityFramework
* Docker
* Web Api
* Web Site ( padrão MVC )
* Test nUnit


## Funcionalidades e Demonstração da Aplicação;

### Simulação de Custo

Para realizar a simulação, basta selecionar o DDD de Origem e Destino, definir o tempo de duração da chamada e clicar em Simular. 

Caso queira limpar a tela de simulação, clique no botão Limpar.

![image](https://user-images.githubusercontent.com/23090367/177054681-1b09cdb1-d379-4149-9de1-484b117a1a5b.png)

![image](https://user-images.githubusercontent.com/23090367/177054702-7333f9f5-4ea9-46d9-ad92-bbd1be1dc3c2.png)

### Cadastro de Tarifa
![image](https://user-images.githubusercontent.com/23090367/177054610-39a1027e-729b-433c-8847-d395b5667dc0.png)

![image](https://user-images.githubusercontent.com/23090367/177054626-760f5231-ddf1-4623-8d7b-9376f119e4f4.png)

![image](https://user-images.githubusercontent.com/23090367/177054637-5ccfe37d-1845-41ea-abd7-c5313cc1856f.png)

![image](https://user-images.githubusercontent.com/23090367/177054646-91e10b62-2ef0-44f3-9e5a-d35015471894.png)

![image](https://user-images.githubusercontent.com/23090367/177054658-e0115568-8f84-4250-b667-39981e4b82f0.png)

### Cadastro de Produtos

![image](https://user-images.githubusercontent.com/23090367/177054716-d27e5bfb-0859-4ce7-9c40-d8b7b63f8281.png)

![image](https://user-images.githubusercontent.com/23090367/177054733-c9413eb2-39b2-4179-a7dd-e1d9c3d655f0.png)

![image](https://user-images.githubusercontent.com/23090367/177054830-cb8ef85e-03c2-4692-83c0-86d0e6d90378.png)

![image](https://user-images.githubusercontent.com/23090367/177054849-6d787ea4-1ff4-4e7a-b567-779db4f5b24f.png)

![image](https://user-images.githubusercontent.com/23090367/177054864-a11bbc61-5f7d-4fb2-8a43-c228ca62bf8d.png)
