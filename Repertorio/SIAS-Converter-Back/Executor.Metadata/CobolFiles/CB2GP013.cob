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
           77  CODCLIEN                           PIC X(254).
           77  CODSUBES                           PIC X(254).
           77  FONTE                              PIC X(254).
           77  NRPROPOS                           PIC X(254).
           77  RAMO                               PIC X(254).
           77  TIPSEGU                            PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  COD-MOEDA-PRM                      PIC X(254).
           77  DTEMIS                             PIC X(254).
           77  TIPO-ENDOSSO                       PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  CORRECAO                           PIC X(254).
           77  CODPRODU                           PIC X(254).
           77  NRRCAP                             PIC X(254).
           77  ORGAO                              PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
        NRENDOS
       CODCLIEN
       CODSUBES
          FONTE
       NRPROPOS
           RAMO
        TIPSEGU
       DTINIVIG
       DTTERVIG
  COD-MOEDA-PRM
         DTEMIS
   TIPO-ENDOSSO
       SITUACAO
       CORRECAO
       CODPRODU
         NRRCAP
          ORGAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT CODCLIEN, NUM_APOLICE, NRENDOS, CODSUBES, FONTE, NRPROPOS, RAMO, TIPSEGU, DTINIVIG, DTTERVIG, COD_MOEDA_PRM, DTEMIS, TIPO_ENDOSSO, SITUACAO, CORRECAO, CODPRODU, NRRCAP, ORGAO FROM seguros.v1endosso WHERE NUM_APOLICE = :NUM_APOLICE AND NRENDOS = :NRENDOS END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
