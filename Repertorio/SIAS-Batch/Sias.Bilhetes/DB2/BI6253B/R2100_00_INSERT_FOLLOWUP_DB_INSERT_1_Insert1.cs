using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.FOLLOW_UP
            (NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            DAC_PARCELA ,
            DATA_MOVIMENTO ,
            HORA_OPERACAO ,
            VAL_OPERACAO ,
            BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            COD_BAIXA_PARCELA ,
            COD_ERRO01 ,
            COD_ERRO02 ,
            COD_ERRO03 ,
            COD_ERRO04 ,
            COD_ERRO05 ,
            COD_ERRO06 ,
            SIT_REGISTRO ,
            SIT_CONTABIL ,
            COD_OPERACAO ,
            DATA_LIBERACAO ,
            DATA_QUITACAO ,
            COD_EMPRESA ,
            TIMESTAMP ,
            ORDEM_LIDER ,
            TIPO_SEGURO ,
            NUM_APOL_LIDER ,
            ENDOS_LIDER ,
            COD_LIDER ,
            COD_FONTE ,
            NUM_RCAP ,
            NUM_NOSSO_TITULO)
            VALUES
            (:FOLLOUP-NUM-APOLICE ,
            :FOLLOUP-NUM-ENDOSSO ,
            :FOLLOUP-NUM-PARCELA ,
            :FOLLOUP-DAC-PARCELA ,
            :FOLLOUP-DATA-MOVIMENTO ,
            :FOLLOUP-HORA-OPERACAO ,
            :FOLLOUP-VAL-OPERACAO ,
            :FOLLOUP-BCO-AVISO ,
            :FOLLOUP-AGE-AVISO ,
            :FOLLOUP-NUM-AVISO-CREDITO ,
            :FOLLOUP-COD-BAIXA-PARCELA ,
            :FOLLOUP-COD-ERRO01 ,
            :FOLLOUP-COD-ERRO02 ,
            :FOLLOUP-COD-ERRO03 ,
            :FOLLOUP-COD-ERRO04 ,
            :FOLLOUP-COD-ERRO05 ,
            :FOLLOUP-COD-ERRO06 ,
            :FOLLOUP-SIT-REGISTRO ,
            :FOLLOUP-SIT-CONTABIL ,
            :FOLLOUP-COD-OPERACAO ,
            :FOLLOUP-DATA-LIBERACAO:VIND-DTLIBER ,
            :FOLLOUP-DATA-QUITACAO:VIND-DTQITBCO ,
            :FOLLOUP-COD-EMPRESA:VIND-CODEMP ,
            CURRENT TIMESTAMP ,
            :FOLLOUP-ORDEM-LIDER:VIND-ORDLIDER ,
            :FOLLOUP-TIPO-SEGURO:VIND-TIPSGU ,
            :FOLLOUP-NUM-APOL-LIDER:VIND-APOLIDER,
            :FOLLOUP-ENDOS-LIDER:VIND-ENDOSLID ,
            :FOLLOUP-COD-LIDER:VIND-CODLIDER ,
            :FOLLOUP-COD-FONTE:VIND-FONTE ,
            :FOLLOUP-NUM-RCAP:VIND-NRRCAP ,
            :FOLLOUP-NUM-NOSSO-TITULO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.FOLLOW_UP (NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DAC_PARCELA , DATA_MOVIMENTO , HORA_OPERACAO , VAL_OPERACAO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , COD_BAIXA_PARCELA , COD_ERRO01 , COD_ERRO02 , COD_ERRO03 , COD_ERRO04 , COD_ERRO05 , COD_ERRO06 , SIT_REGISTRO , SIT_CONTABIL , COD_OPERACAO , DATA_LIBERACAO , DATA_QUITACAO , COD_EMPRESA , TIMESTAMP , ORDEM_LIDER , TIPO_SEGURO , NUM_APOL_LIDER , ENDOS_LIDER , COD_LIDER , COD_FONTE , NUM_RCAP , NUM_NOSSO_TITULO) VALUES ({FieldThreatment(this.FOLLOUP_NUM_APOLICE)} , {FieldThreatment(this.FOLLOUP_NUM_ENDOSSO)} , {FieldThreatment(this.FOLLOUP_NUM_PARCELA)} , {FieldThreatment(this.FOLLOUP_DAC_PARCELA)} , {FieldThreatment(this.FOLLOUP_DATA_MOVIMENTO)} , {FieldThreatment(this.FOLLOUP_HORA_OPERACAO)} , {FieldThreatment(this.FOLLOUP_VAL_OPERACAO)} , {FieldThreatment(this.FOLLOUP_BCO_AVISO)} , {FieldThreatment(this.FOLLOUP_AGE_AVISO)} , {FieldThreatment(this.FOLLOUP_NUM_AVISO_CREDITO)} , {FieldThreatment(this.FOLLOUP_COD_BAIXA_PARCELA)} , {FieldThreatment(this.FOLLOUP_COD_ERRO01)} , {FieldThreatment(this.FOLLOUP_COD_ERRO02)} , {FieldThreatment(this.FOLLOUP_COD_ERRO03)} , {FieldThreatment(this.FOLLOUP_COD_ERRO04)} , {FieldThreatment(this.FOLLOUP_COD_ERRO05)} , {FieldThreatment(this.FOLLOUP_COD_ERRO06)} , {FieldThreatment(this.FOLLOUP_SIT_REGISTRO)} , {FieldThreatment(this.FOLLOUP_SIT_CONTABIL)} , {FieldThreatment(this.FOLLOUP_COD_OPERACAO)} ,  {FieldThreatment((this.VIND_DTLIBER?.ToInt() == -1 ? null : this.FOLLOUP_DATA_LIBERACAO))} ,  {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.FOLLOUP_DATA_QUITACAO))} ,  {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.FOLLOUP_COD_EMPRESA))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_ORDLIDER?.ToInt() == -1 ? null : this.FOLLOUP_ORDEM_LIDER))} ,  {FieldThreatment((this.VIND_TIPSGU?.ToInt() == -1 ? null : this.FOLLOUP_TIPO_SEGURO))} ,  {FieldThreatment((this.VIND_APOLIDER?.ToInt() == -1 ? null : this.FOLLOUP_NUM_APOL_LIDER))},  {FieldThreatment((this.VIND_ENDOSLID?.ToInt() == -1 ? null : this.FOLLOUP_ENDOS_LIDER))} ,  {FieldThreatment((this.VIND_CODLIDER?.ToInt() == -1 ? null : this.FOLLOUP_COD_LIDER))} ,  {FieldThreatment((this.VIND_FONTE?.ToInt() == -1 ? null : this.FOLLOUP_COD_FONTE))} ,  {FieldThreatment((this.VIND_NRRCAP?.ToInt() == -1 ? null : this.FOLLOUP_NUM_RCAP))} , {FieldThreatment(this.FOLLOUP_NUM_NOSSO_TITULO)})";

            return query;
        }
        public string FOLLOUP_NUM_APOLICE { get; set; }
        public string FOLLOUP_NUM_ENDOSSO { get; set; }
        public string FOLLOUP_NUM_PARCELA { get; set; }
        public string FOLLOUP_DAC_PARCELA { get; set; }
        public string FOLLOUP_DATA_MOVIMENTO { get; set; }
        public string FOLLOUP_HORA_OPERACAO { get; set; }
        public string FOLLOUP_VAL_OPERACAO { get; set; }
        public string FOLLOUP_BCO_AVISO { get; set; }
        public string FOLLOUP_AGE_AVISO { get; set; }
        public string FOLLOUP_NUM_AVISO_CREDITO { get; set; }
        public string FOLLOUP_COD_BAIXA_PARCELA { get; set; }
        public string FOLLOUP_COD_ERRO01 { get; set; }
        public string FOLLOUP_COD_ERRO02 { get; set; }
        public string FOLLOUP_COD_ERRO03 { get; set; }
        public string FOLLOUP_COD_ERRO04 { get; set; }
        public string FOLLOUP_COD_ERRO05 { get; set; }
        public string FOLLOUP_COD_ERRO06 { get; set; }
        public string FOLLOUP_SIT_REGISTRO { get; set; }
        public string FOLLOUP_SIT_CONTABIL { get; set; }
        public string FOLLOUP_COD_OPERACAO { get; set; }
        public string FOLLOUP_DATA_LIBERACAO { get; set; }
        public string VIND_DTLIBER { get; set; }
        public string FOLLOUP_DATA_QUITACAO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string FOLLOUP_COD_EMPRESA { get; set; }
        public string VIND_CODEMP { get; set; }
        public string FOLLOUP_ORDEM_LIDER { get; set; }
        public string VIND_ORDLIDER { get; set; }
        public string FOLLOUP_TIPO_SEGURO { get; set; }
        public string VIND_TIPSGU { get; set; }
        public string FOLLOUP_NUM_APOL_LIDER { get; set; }
        public string VIND_APOLIDER { get; set; }
        public string FOLLOUP_ENDOS_LIDER { get; set; }
        public string VIND_ENDOSLID { get; set; }
        public string FOLLOUP_COD_LIDER { get; set; }
        public string VIND_CODLIDER { get; set; }
        public string FOLLOUP_COD_FONTE { get; set; }
        public string VIND_FONTE { get; set; }
        public string FOLLOUP_NUM_RCAP { get; set; }
        public string VIND_NRRCAP { get; set; }
        public string FOLLOUP_NUM_NOSSO_TITULO { get; set; }

        public static void Execute(R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1 r2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_INSERT_FOLLOWUP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}