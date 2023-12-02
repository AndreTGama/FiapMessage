# Projeto Monolito com RabbitMQ - C#

Este projeto monolítico, desenvolvido em C#, utiliza o RabbitMQ para comunicação assíncrona entre três aplicações distintas: Core, Produtor e Consumidor.

## Estrutura do Projeto

### Core
A aplicação Core é a base do projeto, contendo apenas duas classes principais: `Pedidos` e `Usuario`. Essas classes representam entidades do sistema e fornecem dados para o processo de comunicação entre as aplicações.

### Produtor
O Produtor desempenha o papel de produtor no RabbitMQ. Sua função é enviar eventos para a fila do RabbitMQ, notificando sobre a criação de novos pedidos ou usuários.

### Consumidor
O Consumidor é responsável por receber e processar os eventos da fila do RabbitMQ. Neste projeto, ele exibe as informações no terminal usando `Console.WriteLine`.

## Como Funciona

1. Ao executar a aplicação Core, as classes `Pedidos` e `Usuario` são inicializadas.

2. O Produtor, ao identificar uma nova criação de pedido ou usuário, envia um evento para a fila do RabbitMQ.

3. O Consumidor, aguardando na fila, recebe os eventos e processa-os, exibindo as informações no terminal.

## Executando o Projeto

1. Certifique-se de ter o RabbitMQ instalado e em execução na máquina.

2. Execute a aplicação Core para criar instâncias de pedidos e usuários.

3. Execute o Produtor para enviar os eventos para a fila.

4. Execute o Consumidor para visualizar as informações no terminal.

## Observações

Este projeto foi desenvolvido com base nas aulas da FIAP e segue uma abordagem didática para facilitar o entendimento do uso do RabbitMQ em um cenário monolítico em C#.
