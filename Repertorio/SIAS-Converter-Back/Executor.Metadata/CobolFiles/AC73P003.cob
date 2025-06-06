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
           77  CODCLIEN                           PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  RAMO                               PIC X(254).
           77  NRPROPOS                           PIC X(254).
           77  DTEMIS                             PIC X(254).
           77  TIPAPO                             PIC X(254).
           77  DTINIVIG                           PIC X(254).
           77  DTTERVIG                           PIC X(254).
           77  QTPARCEL                           PIC X(254).
           77  COD-MOEDA-IMP                      PIC X(254).
           77  COD-MOEDA-PRM                      PIC X(254).
           77  TIPO-ENDOSSO                       PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  CORRECAO                           PIC X(254).
           77  ORDLIDER                           PIC X(254).
           77  CODLIDER                           PIC X(254).
           77  PCPARTIC                           PIC X(254).
           77  APOLIDER                           PIC X(254).
           77  ENDOSLID                           PIC X(254).
           77  DTEMILID                           PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
       CODCLIEN
        NRENDOS
           RAMO
       NRPROPOS
         DTEMIS
         TIPAPO
       DTINIVIG
       DTTERVIG
       QTPARCEL
  COD-MOEDA-IMP
  COD-MOEDA-PRM
   TIPO-ENDOSSO
       SITUACAO
       CORRECAO
       ORDLIDER
       CODLIDER
       PCPARTIC
       APOLIDER
       ENDOSLID
       DTEMILID.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT T1.CODCLIEN, T1.NUM_APOLICE, T1.NRENDOS, T1.RAMO, T1.NRPROPOS, T1.DTEMIS, T1.TIPAPO, T1.DTINIVIG, T1.DTTERVIG, T1.QTPARCEL, T1.COD_MOEDA_IMP, T1.COD_MOEDA_PRM, T1.TIPO_ENDOSSO, T1.SITUACAO, T1.CORRECAO, T2.ORDLIDER, T2.CODLIDER, T2.PCPARTIC, T2.APOLIDER, T2.ENDOSLID, T2.DTEMILID FROM seguros.v1endosso T1, seguros.v1endosso T2 WHERE T1.num_apolice = :NUM_APOLICE AND T1.num_apolice = T2.num_apolice AND T1.nrendos = T2.nrendos ORDER BY 16 END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
