# Teste de Desenvolvimento .NET

Primeiramente, agradeço a oportunidade fornecida. 

Seguem as instruções para execução da API:

Clonar o repositório:

```bash
git clone https://github.com/TyroneAmorim/Teste-Desenvolvedor-.NET.git
```
Entrar na pasta:

```bash
cd Teste-Desenvolvedor-.NET

```
Selecionar a branch:

```bash
git checkout teste/tyrone-amorim
```

Entrar na pasta do docker

```bash
cd docker

```

Subir os containers com docker ou podman:


```bash
docker-compose up
```

```bash
podman-compose up
```

Aguarde o banco de dados subir completamente. Para conferir, rode o comando:

```bash
podman exec -it postgres_db pg_isready

```

Se tudo ocorreu bem, aparecerá algo como: 
```bash
...accepting connections
```


A seguir, rode o seguinte comando em uma nova aba do terminal, para importar as migrations no banco:

```bash
podman exec -it api-vestibular dotnet-ef database update --project /src/Infrastructure/Infrastructure.csproj --startup-project /src/Infrastructure/Infrastructure.csproj
```


Com tudo feito, a API estará disponível em:

http://localhost:8098/swagger/index.html

e

https://localhost:8099/swagger/index.html



Link do vídeo de apresentação:

https://youtu.be/Qs0pKt5nPrE
