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
           77  CODSUBES                           PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  NRPARCEL                           PIC X(254).
           77  T1.NRPARCEL                        PIC X(254).
           77  T1.QTDDOC                          PIC X(254).
           77  T1.SITUACAO                        PIC X(254).
           77  T1.OCORHIST                        PIC X(254).
           77  T2.CODSUBES                        PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
       CODSUBES
        NRENDOS
       NRPARCEL
    T1.NRPARCEL
      T1.QTDDOC
    T1.SITUACAO
    T1.OCORHIST
    T2.CODSUBES.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT T1.NRPARCEL, T1.QTDDOC, T1.SITUACAO, T1.OCORHIST, T2.CODSUBES FROM seguros.v1parcela T1, seguros.v1parcela T2 WHERE T1.NUM_APOLICE = :NUM_APOLICE AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T2.CODSUBES = :CODSUBES AND T1.NRENDOS = :NRENDOS AND T1.NRENDOS = T2.NRENDOS AND T1.NRPARCEL = :NRPARCEL END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
