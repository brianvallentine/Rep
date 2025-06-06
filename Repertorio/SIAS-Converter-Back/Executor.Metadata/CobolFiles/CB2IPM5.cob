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
           77  COD-EMPRESA                        PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOSR                           PIC X(254).
           77  NRPARCELR                          PIC X(254).
           77  NRENDOSC                           PIC X(254).
           77  NRPARCELC                          PIC X(254).
           77  OCORHIST                           PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  HORAOPER                           PIC X(254).
           77  VALCREDR                           PIC X(254).
           77  VLPAGTO                            PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  SITCONTB                           PIC X(254).
           77  BCOCOBR                            PIC X(254).
           77  AGECOBR                            PIC X(254).
           77  NUMCHQ                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    COD-EMPRESA
    NUM-APOLICE
       NRENDOSR
      NRPARCELR
       NRENDOSC
      NRPARCELC
       OCORHIST
       OPERACAO
        DTMOVTO
       HORAOPER
       VALCREDR
        VLPAGTO
       DTVENCTO
       SITCONTB
        BCOCOBR
        AGECOBR
         NUMCHQ.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0histnotcre (COD_EMPRESA, NUM_APOLICE, NRENDOSR, NRPARCELR, NRENDOSC, NRPARCELC, OCORHIST, OPERACAO, DTMOVTO, HORAOPER, VALCREDR, VLPAGTO, DTVENCTO, SITCONTB, BCOCOBR, AGECOBR, NUMCHQ) VALUES (:COD_EMPRESA, :NUM_APOLICE, :NRENDOSR, :NRPARCELR, :NRENDOSC, :NRPARCELC, :OCORHIST, :OPERACAO, :DTMOVTO, :HORAOPER, :VALCREDR, :VLPAGTO, :DTVENCTO, :SITCONTB, :BCOCOBR, :AGECOBR, :NUMCHQ) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
