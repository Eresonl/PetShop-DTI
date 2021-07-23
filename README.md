# DTI Pet-shop
Repositório referente ao processo seletivo da DTI. esta solução foi desenvolvida em C# VS2019
>Requisitos de entrada: 
>  <data.><quantidade de cães pequenos>< quantidade de caes grandes>
>  

>Requisitos de saida: 
>Nome do melhor canil e preço total dos banhos.
# Premissas
- Priorizar a menor distancia se valores forem iguais
- Alterar valores aos finais de semana
- Trabalhar com os valores de % já adicionados aos valores.
# Decisões do Projeto 
- Ultilizar uma regra booleana para saber se a data e final de semana 
- Criar uma string para cada canil e criar valores constantes de distancia e preços dentro dessas strings
- Ultilizar try cath e tryparse para validar as regras de negócio e excessões

# Instruções para executar o sistema
O sistema devera ser executado pelo arquivo Agendamento-PetShop.exe Localizado na pasta PetShop-DTI\Agendamento-PetShop\bin\Debug\netcoreapp3.1.\publish
