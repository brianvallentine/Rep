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
           77  NUM-ENDOSSO                        PIC X(254).
           77  NUM-PARCELA                        PIC X(254).
           77  DTA-VENCTO                         PIC X(254).
           77  NUM-VENCTO                         PIC X(254).
           77  VLR-PREMIO-LIQUIDO                 PIC X(254).
           77  VLR-JUROS                          PIC X(254).
           77  VLR-ADIC-FRAC                      PIC X(254).
           77  VLR-MULTA                          PIC X(254).
           77  VLR-CUSTO                          PIC X(254).
           77  VLR-IOF                            PIC X(254).
           77  VLR-PREMIO-TOTAL                   PIC X(254).
           77  NUM-RECIBO-CONV                    PIC X(254).
           77  COD-USUARIO                        PIC X(254).
           77  DTH-TIMESTAMP                      PIC X(254).
           77  DATE                               PIC X(254).
           77  DTA-VENCTO                         PIC X(254).
           77  10                                 PIC X(254).
           77  DAYS                               PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
    NUM-ENDOSSO
    NUM-PARCELA
     DTA-VENCTO
     NUM-VENCTO
VLR-PREMIO-LIQUIDO
      VLR-JUROS
  VLR-ADIC-FRAC
      VLR-MULTA
      VLR-CUSTO
        VLR-IOF
VLR-PREMIO-TOTAL
NUM-RECIBO-CONV
    COD-USUARIO
  DTH-TIMESTAMP
           DATE
     DTA-VENCTO
             10
           DAYS.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR  SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DTA_VENCTO, NUM_VENCTO, VLR_PREMIO_LIQUIDO, VLR_JUROS, VLR_ADIC_FRAC, VLR_MULTA, VLR_CUSTO, VLR_IOF, VLR_PREMIO_TOTAL, NUM_RECIBO_CONV, COD_USUARIO, DTH_TIMESTAMP, DATE(DTA_VENCTO, +, 10DAYS)
               FROM SEGUROS.PARCELA_AUTO_COMPL
               
                END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
