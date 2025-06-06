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
           77  NUM-APOLICE                        PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  DACPARC                            PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  HORAOPER                           PIC X(254).
           77  VLPREMIO                           PIC X(254).
           77  BCOAVISO                           PIC X(254).
           77  AGEAVISO                           PIC X(254).
           77  NRAVISO                            PIC X(254).
           77  CODBAIXA                           PIC X(254).
           77  CDERRO01                           PIC X(254).
           77  CDERRO02                           PIC X(254).
           77  CDERRO03                           PIC X(254).
           77  CDERRO04                           PIC X(254).
           77  CDERRO05                           PIC X(254).
           77  CDERRO06                           PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  SITCONTB                           PIC X(254).
           77  OPERACAO                           PIC X(254).
           77  DTLIBER                            PIC X(254).
           77  DTQITBCO                           PIC X(254).
           77  COD-EMPRESA                        PIC X(254).
           77  ORDLIDER                           PIC X(254).
           77  TIPSGU                             PIC X(254).
           77  APOLIDER                           PIC X(254).
           77  ENDOSLID                           PIC X(254).
           77  CODLIDER                           PIC X(254).
           77  NRRCAP                             PIC X(254).
           77  FONTE                              PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       NRPARCEL
        DACPARC
        DTMOVTO
       HORAOPER
       VLPREMIO
       BCOAVISO
       AGEAVISO
        NRAVISO
       CODBAIXA
       CDERRO01
       CDERRO02
       CDERRO03
       CDERRO04
       CDERRO05
       CDERRO06
       SITUACAO
       SITCONTB
       OPERACAO
        DTLIBER
       DTQITBCO
    COD-EMPRESA
       ORDLIDER
         TIPSGU
       APOLIDER
       ENDOSLID
       CODLIDER
         NRRCAP
          FONTE.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR INSERT INTO seguros.v0followup(NUM_APOLICE, NRENDOS, NRPARCEL, DACPARC, DTMOVTO, HORAOPER, VLPREMIO, BCOAVISO, AGEAVISO, NRAVISO, CODBAIXA, CDERRO01, CDERRO02, CDERRO03, CDERRO04, CDERRO05, CDERRO06, SITUACAO, SITCONTB, OPERACAO, DTLIBER, DTQITBCO, COD_EMPRESA, TIMESTAMP, ORDLIDER, TIPSGU, APOLIDER, ENDOSLID, CODLIDER, NRRCAP, FONTE) VALUES (:NUM_APOLICE, :NRENDOS, :NRPARCEL, :DACPARC, :DTMOVTO, :HORAOPER, :VLPREMIO, :BCOAVISO, :AGEAVISO, :NRAVISO, :CODBAIXA, :CDERRO01, :CDERRO02, :CDERRO03, :CDERRO04, :CDERRO05, :CDERRO06, :SITUACAO, :SITCONTB, :OPERACAO, :DTLIBER, :DTQITBCO, :COD_EMPRESA, CURRENT TIMESTAMP, :ORDLIDER, :TIPSGU, :APOLIDER, :ENDOSLID, :CODLIDER, :NRRCAP, :FONTE) END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
