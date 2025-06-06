       IDENTIFICATION DIVISION.                                                 
       PROGRAM-ID. AC10P013.                                                    
                                                                                
      *---------------------*                                                   
       ENVIRONMENT DIVISION.                                                    
      *---------------------*                                                   
                                                                                
      *---------------------*                                                   
       CONFIGURATION SECTION.                                                   
      *---------------------*                                                   
                                                                                
      *-------------*                                                           
       SPECIAL-NAMES.                                                           
      *-------------*                                                           
           DECIMAL-POINT IS COMMA.                                              
                                                                                
      *--------------------*                                                    
       INPUT-OUTPUT SECTION.                                                    
      *--------------------*                                                    
                                                                                
      *-------------*                                                           
       DATA DIVISION.                                                           
      *-------------*                                                           
      *                                                                         
      *-----------------------*                                                 
       WORKING-STORAGE SECTION.                                                 
      *-----------------------*                                                 
             
      *----------------------------------------------------------------*        
      *- VARIAVEIS AUXILIARES                                          *        
      *----------------------------------------------------------------*        
                                                                                     
      *>    05  LK-TIP-CALC                        PIC 9(001) VALUE ZEROS .            
      *>    05  LK-NUM-APOL                        PIC 9(001) VALUE ZEROS .           
      *>    05  LK-NRENDOS                         PIC 9(001) VALUE ZEROS .   
      *>    05  LK-DTINIVIG                     OCCURS      2000   TIMES               
      *>                                        INDEXED      BY    WIND.          
      *>        10      WTABG-CODPRODU             PIC S9(004)        COMP.               
      *>            15  WTABG-OCORRETIP         OCCURS       003   TIMES       
      *>                                        INDEXED      BY    WIND2.     
      *>                25    WTABG-TIPO  PIC  X(001).                 

      *>   77  LK-TIP-CALC                        PIC X(254).
           77  CPF                                PIC X(254).
           77  DATA-NASCIMENTO                    PIC X(254).
           77  SEXO                               PIC X(254).
           77  COD-PESSOA                         PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  ESTADO-CIVIL                       PIC X(254).
           77  TIMESTAMP                          PIC X(254).
           77  NUM-IDENTIDADE                     PIC X(254).
           77  ORGAO-EXPEDIDOR                    PIC X(254).
           77  UF-EXPEDIDORA                      PIC X(254).
           77  DATA-EXPEDICAO                     PIC X(254).
           77  COD-CBO                            PIC X(254).
           77  TIPO-IDENT-SIVPF                   PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
            CPF
DATA-NASCIMENTO
           SEXO
     COD-PESSOA
    COD-USUARIO
   ESTADO-CIVIL
      TIMESTAMP
 NUM-IDENTIDADE
ORGAO-EXPEDIDOR
  UF-EXPEDIDORA
 DATA-EXPEDICAO
        COD-CBO
TIPO-IDENT-SIVPF.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, TIPO_IDENT_SIVPF FROM SEGUROS.GE_PESSOA_FISICA WHERE CPF = :CPF AND DATA_NASCIMENTO = :DATA_NASCIMENTO AND SEXO = :SEXO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
