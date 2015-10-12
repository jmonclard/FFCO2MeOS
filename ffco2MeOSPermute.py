import sys
import time
import pays
from datetime import datetime
from pays import GetCountryCode

def Ecrire(fic,indent,ligne):
    for i in range(indent):
        fic.write("\t")
    fic.write(ligne)
    fic.write("\n")
    return None    


def ffco2iof(source, dest):
    f_in=open(source,encoding='mbcs', mode='r')
    donnees=f_in.readlines()
    f_in.close()
    lig=1
    nbr=0
    if len(donnees)>1:
        f_out=open(dest, encoding='utf-8', mode='w')

     
        #creation de l'entete
        dt=datetime.now()
        str_dt = dt.strftime("%Y-%m-%dT%H:%M:%S")
        Ecrire(f_out,0,'<?xml version="1.0" encoding="UTF-8"?>')
        Ecrire(f_out,0,"<CompetitorList creator=\"ffco2MeOS\" createTime=\""+str_dt+"\" iofVersion=\"3.0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.orienteering.org/datastandard/3.0\">")

        for ligne in donnees[1:]:
            ligne_decoupee=ligne.split(";")
            if len(ligne_decoupee)>12:
                Ecrire(f_out,1,"<Competitor>")
                licence = ligne_decoupee[0].strip()
                puce = ligne_decoupee[1].strip()
                nom = ligne_decoupee[2].strip()
                prenom = ligne_decoupee[3].strip()
                annee_naissance = ligne_decoupee[4].strip()
                if ligne_decoupee[4].strip()=="F":
                    sexe="F"
                elif ligne_decoupee[4].strip()=="H":
                    sexe="M"
                else:
                    sexe="?"
                num_club = ligne_decoupee[7].strip()
                nom_club = ligne_decoupee[8].strip()
                nationalite = ligne_decoupee[9].strip()
                nom_court_categ = ligne_decoupee[11].strip()
                nom_long_categ = ligne_decoupee[12].strip()

                #<person>
                if sexe=="?":
                    Ecrire(f_out,2,"<Person>")
                else:
                    Ecrire(f_out,2,"<Person sex=\""+sexe+"\">")
                Ecrire(f_out,3,"<Id>"+licence+"</Id>")
                Ecrire(f_out,3,"<Name>")
                Ecrire(f_out,4,"<Family>"+nom+"</Family>")
                Ecrire(f_out,4,"<Given>"+prenom+"</Given>")
                Ecrire(f_out,3,"</Name>")
                Ecrire(f_out,3,"<BirthDate>"+annee_naissance+"-01-01</BirthDate>")
                Ecrire(f_out,3,"<Nationality code=\""+GetCountryCode(nationalite)+"\">"+nationalite+"</Nationality>")
                Ecrire(f_out,2,"</Person>")

                #<organisation>
                Ecrire(f_out,2,"<Organisation>")
                Ecrire(f_out,3,"<Id>"+num_club+"</Id>")
                Ecrire(f_out,3,"<Name>"+nom_club+"</Name>")
                Ecrire(f_out,3,"<Nationality code=\""+GetCountryCode(nationalite)+"\">"+nationalite+"</Nationality>")
                Ecrire(f_out,2,"</Organisation>")

                #<ControlCard>
                Ecrire(f_out,2,"<ControlCard punchingSystem=\"SI\">"+puce+"</ControlCard>")

                #<class>
                Ecrire(f_out,2,"<Class>")
                Ecrire(f_out,3,"<Id>"+nom_court_categ+"</Id>")
                Ecrire(f_out,3,"<Name>"+nom_long_categ+"</Name>")
                Ecrire(f_out,2,"</Class>")
                
                Ecrire(f_out,1,"</Competitor>")
                nbr+=1    
                
            else:
                print("Erreur ligne "+str(lig)+". Nombre de paramètres insuffisant.")

            lig+=1
        Ecrire(f_out,0,"</CompetitorList>")
        f_out.close()
    print("nb lignes converties = "+str(nbr)+" sur "+str(lig)+".")
    print("N.B. : Un écart de 1 est normal (ligne de titre)")
    return None



l=len(sys.argv)

def main():
    if l==3:
        ffco2iof(sys.argv[1],sys.argv[2])
    else:
        print("Usage : ffco2MeOS <nom_fichier_CSV> <nom_fichier_XML_a_creer>")
        print ("Exemple : C:\Python33\python.exe ffco2MeOs.py licencesFFCO-2014-au-19-05-2014.csv licencesFFCO-2014-au-19-05-2014.xml")
        print("Nombre arguments actuel:"+str(l))
        for a in sys.argv:
            print("\t"+a)
        
main()
