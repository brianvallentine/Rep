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
           77  COD-CONVENIO                       PIC X(254).
           77  NRENDOS                            PIC X(254).
           77  COD-AGENCIA-DEB                    PIC X(254).
           77  OPER-CONTA-DEB                     PIC X(254).
           77  NUM-CONTA-DEB                      PIC X(254).
           77  DIG-CONTA-DEB                      PIC X(254).
           77  NUM-CARTAO                         PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
   COD-CONVENIO
        NRENDOS
COD-AGENCIA-DEB
 OPER-CONTA-DEB
  NUM-CONTA-DEB
  DIG-CONTA-DEB
     NUM-CARTAO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT T1.COD_CONVENIO, T1.NUM_APOLICE, T1.NRENDOS, T1.COD_AGENCIA_DEB, T1.OPER_CONTA_DEB, T1.NUM_CONTA_DEB, T1.DIG_CONTA_DEB, T1.NUM_CARTAO FROM SEGUROS.V0MOVDEBCC_CEF T1, SEGUROS.V0MOVDEBCC_CEF T2 WHERE T1.NUM_APOLICE = :NUM_APOLICE AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T2.RAMO_EMISSOR IN (31,53,14,18,67,71) GROUP BY T1.COD_CONVENIO, T1.NUM_APOLICE, T1.NRENDOS, T1.COD_AGENCIA_DEB, T1.OPER_CONTA_DEB, T1.NUM_CONTA_DEB, T1.DIG_CONTA_DEB, T1.NUM_CARTAO ORDER BY T1.COD_CONVENIO, T1.NUM_APOLICE, T1.NRENDOS, T1.COD_AGENCIA_DEB, T1.OPER_CONTA_DEB, T1.NUM_CONTA_DEB, T1.DIG_CONTA_DEB, T1.NUM_CARTAO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            
