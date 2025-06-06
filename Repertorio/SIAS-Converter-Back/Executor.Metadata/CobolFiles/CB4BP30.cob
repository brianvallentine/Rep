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
           77  COD-EMPRESA                        PIC X(254).
           77  VLPRMTOT                           PIC X(254).
           77  VLACRESCIMO                        PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  DTVENCTO                           PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  TIMESTAMP                          PIC X(254).
           77  NRTIT                              PIC X(254).
           77  DT-NOVENCTO                        PIC X(254).
           77  DT-CANCPREV                        PIC X(254).
           77  NUM-LOTE                           PIC X(254).
           77  DAT-LOTE                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       NRPARCEL
    COD-EMPRESA
       VLPRMTOT
    VLACRESCIMO
       SITUACAO
        DTMOVTO
       DTVENCTO
    COD-USUARIO
      TIMESTAMP
          NRTIT
    DT-NOVENCTO
    DT-CANCPREV
       NUM-LOTE
       DAT-LOTE.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT COD_EMPRESA, NUM_APOLICE, NRENDOS, NRPARCEL, VLPRMTOT, VLACRESCIMO, SITUACAO, DTMOVTO, DTVENCTO, COD_USUARIO, TIMESTAMP, value(NRTIT,0), value(DT_NOVENCTO,date('0001-01-01')), value(DT_CANCPREV,date('0001-01-01')), NUM_LOTE, value(dat_lote,date('0001-01-01')) FROM seguros.v0parcela_devedor WHERE num_apolice = :NUM_APOLICE AND nrendos = :NRENDOS AND nrparcel = :NRPARCEL END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
