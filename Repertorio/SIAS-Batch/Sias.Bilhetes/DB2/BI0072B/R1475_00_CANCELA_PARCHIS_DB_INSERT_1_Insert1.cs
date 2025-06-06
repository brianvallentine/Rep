using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1 : QueryBasis<R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PARCELA_HISTORICO
            SELECT NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            DAC_PARCELA ,
            :V1SIST-DTMOVABE ,
            401 COD_OPERACAO ,
            HORA_OPERACAO ,
            OCORR_HISTORICO + 1 ,
            PRM_TARIFARIO ,
            VAL_DESCONTO ,
            PRM_LIQUIDO ,
            ADICIONAL_FRACIO ,
            VAL_CUSTO_EMISSAO ,
            VAL_IOCC ,
            PRM_TOTAL ,
            VAL_OPERACAO ,
            DATA_VENCIMENTO ,
            BCO_COBRANCA ,
            AGE_COBRANCA ,
            NUM_AVISO_CREDITO ,
            :NUMERAES-ENDOS-CANCELA ENDOS_CANCELA,
            SIT_CONTABIL ,
            'BI0072B' COD_USUARIO,
            RENUM_DOCUMENTO ,
            DATA_QUITACAO ,
            COD_EMPRESA ,
            CURRENT TIMESTAMP
            FROM SEGUROS.PARCELA_HISTORICO T1
            WHERE T1.NUM_APOLICE = :V0PCHS-NUM-APOLICE
            AND T1.NUM_ENDOSSO = :V0PCHS-NUM-ENDOSSO
            AND T1.NUM_PARCELA = :V0PCHS-NUM-PARCELA
            AND T1.OCORR_HISTORICO IN (
            SELECT MAX(T10.OCORR_HISTORICO)
            FROM SEGUROS.PARCELA_HISTORICO T10
            WHERE T1.NUM_APOLICE = T10.NUM_APOLICE
            AND T1.NUM_ENDOSSO = T10.NUM_ENDOSSO
            AND T1.NUM_PARCELA = T10.NUM_PARCELA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELA_HISTORICO SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , {FieldThreatment(this.V1SIST_DTMOVABE)} , 401 COD_OPERACAO , HORA_OPERACAO , OCORR_HISTORICO + 1 , PRM_TARIFARIO , VAL_DESCONTO , PRM_LIQUIDO , ADICIONAL_FRACIO , VAL_CUSTO_EMISSAO , VAL_IOCC , PRM_TOTAL , VAL_OPERACAO , DATA_VENCIMENTO , BCO_COBRANCA , AGE_COBRANCA , NUM_AVISO_CREDITO , {FieldThreatment(this.NUMERAES_ENDOS_CANCELA)} ENDOS_CANCELA, SIT_CONTABIL , 'BI0072B' COD_USUARIO, RENUM_DOCUMENTO , DATA_QUITACAO , COD_EMPRESA , CURRENT TIMESTAMP FROM SEGUROS.PARCELA_HISTORICO T1 WHERE T1.NUM_APOLICE = {FieldThreatment(this.V0PCHS_NUM_APOLICE)} AND T1.NUM_ENDOSSO = {FieldThreatment(this.V0PCHS_NUM_ENDOSSO)} AND T1.NUM_PARCELA = {FieldThreatment(this.V0PCHS_NUM_PARCELA)} AND T1.OCORR_HISTORICO IN ( SELECT MAX(T10.OCORR_HISTORICO) FROM SEGUROS.PARCELA_HISTORICO T10 WHERE T1.NUM_APOLICE = T10.NUM_APOLICE AND T1.NUM_ENDOSSO = T10.NUM_ENDOSSO AND T1.NUM_PARCELA = T10.NUM_PARCELA)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string NUMERAES_ENDOS_CANCELA { get; set; }
        public string V0PCHS_NUM_APOLICE { get; set; }
        public string V0PCHS_NUM_ENDOSSO { get; set; }
        public string V0PCHS_NUM_PARCELA { get; set; }

        public static void Execute(R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1 r1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1)
        {
            var ths = r1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1475_00_CANCELA_PARCHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}