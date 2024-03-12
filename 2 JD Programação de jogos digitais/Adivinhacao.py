import random, time

#Decorações
print("//--JOGO DE ADIVINHAÇÃO--\\       [Criado Por Gabriel F. S. Brigola]")
print("\n")

rode = True
#Dificuldade_do_jogo = int(input("Escolha a Dificuldade do jogo. [1 = facil.] [2 = medio.] [3 = dificil] "))
#if Dificuldade_do_jogo <= 0 or Dificuldade_do_jogo >= 3:
#   print("Digite um numero Valido entre 1 a 3")
while rode:
   Dificuldade_do_jogo = int(input("Escolha a Dificuldade do jogo. [1 = facil.] [2 = medio.] [3 = dificil] "))
   if Dificuldade_do_jogo <= 0 or Dificuldade_do_jogo > 3:
      print("Digite um numero Valido entre 1 a 3")
   else:
      rode = False



if Dificuldade_do_jogo == 1:
   Numeros_Min_do_Sorteio = 0
   Numeros_Max_do_Sorteio = 5
   Numeros_de_vidas = 3
   print("Você tem ", Numeros_de_vidas, "vidas")
   
if Dificuldade_do_jogo == 2:
   Numeros_Min_do_Sorteio = 0
   Numeros_Max_do_Sorteio = 10
   Numeros_de_vidas = 6
   print("Você tem ", Numeros_de_vidas, "vidas")

if Dificuldade_do_jogo == 3:
   Numeros_Min_do_Sorteio = 0
   Numeros_Max_do_Sorteio = 50
   Numeros_de_vidas = 10
   print("Você tem ", Numeros_de_vidas, "vidas")

Sorteio = random.randint(Numeros_Min_do_Sorteio, Numeros_Max_do_Sorteio) 

Contador = 1
while(Contador <= Numeros_de_vidas):
    chute = int(input("Digite o seu chute: \n"))
    if chute == Sorteio:
        print("Boa você acertou o Numero. O Numero Era: ", Sorteio)
        time.sleep(0.2)
        print("//--FIM DE JOGO--\\")
        time.sleep(0.2)
        break
    elif chute >= Sorteio:
        print("O Numero do Sorteio é Menor")
        Contador += 1
    elif chute <= Sorteio:
        print("Você Errou: O Numero do Sorteio é maior")
        Contador += 1