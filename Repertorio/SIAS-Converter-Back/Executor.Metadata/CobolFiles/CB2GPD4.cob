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
           77  BANCO                              PIC X(254).
           77  AGENCIA                            PIC X(254).
           77  DIGITO                             PIC X(254).
           77  NOMEBCO                            PIC X(254).
           77  NOME-ABREVIADO                     PIC X(254).
           77  NOMEAGE                            PIC X(254).
           77  TIPOBCO                            PIC X(254).
           77  NRCONTAC                           PIC X(254).
           77  ENDERBCO                           PIC X(254).
           77  CEP                                PIC X(254).
           77  CIDADE                             PIC X(254).
           77  ESTADO                             PIC X(254).
           77  TELEFONE                           PIC X(254).
           77  SITUACAO                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
          BANCO
        AGENCIA
         DIGITO
        NOMEBCO
 NOME-ABREVIADO
        NOMEAGE
        TIPOBCO
       NRCONTAC
       ENDERBCO
            CEP
         CIDADE
         ESTADO
       TELEFONE
       SITUACAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT BANCO, AGENCIA, DIGITO, NOMEBCO, NOME_ABREVIADO, NOMEAGE, TIPOBCO, NRCONTAC, ENDERBCO, CEP, CIDADE, ESTADO, TELEFONE, SITUACAO FROM seguros.v1banco WHERE banco = :BANCO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
