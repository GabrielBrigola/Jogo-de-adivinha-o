import random

# Lista de palavras e suas dicas
palavras_e_dicas = {
    "python": "Seu icone tem duas cobras",
    "java": "foi usada para fazer o jogo de sobrevivência mais famoso",
    "html": "Linguagem que os sites usam"
}

def escolher_palavra_e_dica():
    # Escolhe uma palavra aleatória e sua dica correspondente
    palavra = random.choice(list(palavras_e_dicas.keys()))
    dica = palavras_e_dicas[palavra]
    return palavra, dica

def jogar_forca():
    # Escolhe uma palavra e sua dica
    palavra, dica = escolher_palavra_e_dica()
    letras_corretas = []
    tentativas = 6
    
    while tentativas > 0:
        # Cria a palavra secreta com letras adivinhadas e espaços para letras não adivinhadas
        palavra_secreta = "".join(letra if letra in letras_corretas else "_" for letra in palavra)
        
        print("\nPalavra: " + palavra_secreta)
        print("Tentativas restantes:", tentativas)
        if tentativas == 3:
                print("Dica: ", dica)
        
        if palavra_secreta == palavra:
            print("\nParabéns! Você acertou a palavra:", palavra)
            break
        
        letra_tentativa = input("Digite uma letra: ").lower()
        
        if letra_tentativa in palavra:
            print("Letra correta!")
            letras_corretas.append(letra_tentativa)
        else:
            print("Letra incorreta!")
            tentativas -= 1
    
    if tentativas == 0:
        print("\nVocê perdeu! A palavra era:", palavra)

# Inicia o jogo
jogar_forca()