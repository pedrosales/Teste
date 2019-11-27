**Bem Vindo!**
# 
Este documento README tem como objetivo fornecer as informações necessárias para realização do exame.
 
 
` Objetivo: `
 
- Solução de alguns algoritmos propostos e a construção de uma API.
- Você deve realizar um fork deste repositório e ao finalizar submeter um pull request com a solução ou nos enviar um link do seu repositório.
- Nós avaliaremos o que foi feito e entraremos em contato para dar um parecer.
 
 
`O que será avaliado?`
  
  - A principal ideia do teste é medir sua capacidade lógica e conhecimento na linguagem e seus frameworks
  - Qualidade do seu código
  - Sua capacidade de deixar o projeto organizado
  - Capacidade de tomar decisões
 
`Informações Importantes: `
 
- Independente de onde chegou no teste, nos envie para analisarmos, ninguém precisa ser perfeito!
- Não se esqueça de enviar um script para carga inicial dos dados no banco ou planejar a carga inicial programaticamente.
- Vamos executar sua API e verificar as requests com o postman =)
 
`Seu arquivo Readme.md deve conter: `
 
- Informação de como executar o seu código, descrevendo as rotas que criou e seus contratos.
- Instruções para executar os testes ( preferencialmente queremos fazer isto via linha de comando )
- Os algoritmos estarão na pasta Algoritmos, você é livre para entregá-los na estrutura que desejar. ( incluso no projeto, somente um arquivo de texto, uma classe, um console application, fique a vontade )
 
#
**Algoritmos:**
#
`Duplicados na lista`
 
```
Este algoritmo deve receber como parâmetro um vetor contendo uma sequência de números inteiros
e retornar o índice do primeiro item duplicado.

```
#
`Palindromo`
 
```
Definição: Um palindromo é um string que pode ser lida da mesma forma de trás para frente. Por exemplo, "abcba" ou "arara" é um palindromo.

o que é Palindromo? -> https://pt.wikipedia.org/wiki/Pal%C3%ADndromo
 
Faça um método que deve receber uma string como parâmetro e retornar um bool informando se é palíndromo ou não.
```
 
#
**Agora você deve contruir uma API que contenha:**
```
- Uma funcionalidade para fazer login.
- Uma funcionalidade para cadastrar novas cidades:
  - As cidades devem contar no mínimo com:
    - Um nome e uma estrutura que diga com quem ela faz fronteira
    - Ex: 
      - {"Nome": "A", "Fronteira": ["B", "E"]}
      - {"Nome": "São José", "Fronteira": ["Florianópolis", "Palhoça"]}
- Um meio para retornar todas as cidades já cadastradas ( essa não precisa estar autenticado )
- Um meio para procurar uma cidade especifica
- Um meio que retorne as cidades que fazem fronteira com uma cidade específica
  - Ex: Quem faz fronteira com a Cidade B?
- Retornar a soma dos habitantes de um conjunto de cidades
  - Ex: cidade A,B,C possuem 50 mil habitantes
- Um método pra eu poder atualizar os dados de uma cidade, por exemplo mudar a quantidade de habitantes.
- O caminho que devo fazer de uma cidade a outra
  - Ex: sair de cidade Buenos aires e ir até a cidade Florianópolis
```
 
 
 
`Lembre-se Avaliaremos o que for entregue, mesmo que incompleto`
 
**Boa sorte !!**
 
![alt](https://ajsoifer.files.wordpress.com/2014/04/keep-calm-and-don-t-feed-the-troll-48.png)
