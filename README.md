# validate-password-api
Esse projeto ilustra uma Web Api REST criada em .Net Core 3.1 onde é possível fazer a validação da senha de um usuário.

## Iniciando
Para executar e testar o projeto, será necessário instalar os seguintes programas/SDKs:
- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&passive=false&cid=2030) ou [Visual Studio Code](https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user) para executar o projeto.
- [.Net Core 3.1 ou superior](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-3.1.417-windows-x64-installer) para compilação.
- [Postman](https://dl.pstmn.io/download/latest/win64) ou [Insomnia](https://updates.insomnia.rest/downloads/windows/latest?app=com.insomnia.app&source=website) para simular requisições REST cliente/servidor.
- [Projeto de teste - test-password-validate](https://github.com/heldersaboia/test-password-validate.git) para fazer os testes usando aplicação de criada.

## Desenvolvimento
Para iniciar, é necessário clonar o projeto do GitHub num diretório de sua preferência:

```shell
cd "diretorio de sua preferencia"
git clone https://github.com/heldersaboia/validate-password-api.git
```

Então execute o projeto no Visual Studio (F5) e aplicação iniciará no navegador padrão da sua máquina com a rota padrão http://localhost:37019/ .
A aplicação validará os seguintes critérios para a senha informada:
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial ex.: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

E retornará um objeto JSON com a propriedade "success" com valor booleano 'true' caso seja validado com sucesso além do statuscode http 200 - OK
ou retornará um objeto JSON com a propriedade "success" com valor booleano 'false' e outra propriedade "validations", sendo um array de strings, com as mensagens de validação além do statuscode http 400 - Bad Request

## Testes
Para rodar os testes, pode ser utilizada a aplicação de teste (test-password-validate) criada também em .net core 3.1 mencionada anteriormente.

OU 

Via postman/Insommia fazendo uma requisição do tipo POST para a rota http://localhost:37019/api/user-access/password-validate 
enviando no corpo da requisição um objeto do tipo JSON com as porpriedades "username" e "password" e seu valores. Retornando as validações como mencionadas no tópico Desenvolvimento deste arquivo.
