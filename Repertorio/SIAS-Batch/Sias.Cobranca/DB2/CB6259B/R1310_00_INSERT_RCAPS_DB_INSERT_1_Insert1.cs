using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6259B
{
    public class R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1 : QueryBasis<R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.RCAPS
            (COD_FONTE ,
            NUM_RCAP ,
            NUM_PROPOSTA ,
            NOME_SEGURADO ,
            VAL_RCAP ,
            VAL_RCAP_PRINCIPAL ,
            DATA_CADASTRAMENTO ,
            DATA_MOVIMENTO ,
            SIT_REGISTRO ,
            COD_OPERACAO ,
            COD_EMPRESA ,
            TIMESTAMP ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            NUM_TITULO ,
            CODIGO_PRODUTO ,
            AGE_COBRANCA ,
            RECUPERA ,
            VLACRESCIMO ,
            NUM_CERTIFICADO)
            VALUES
            (:RCAPS-COD-FONTE ,
            :RCAPS-NUM-RCAP ,
            :RCAPS-NUM-PROPOSTA ,
            :RCAPS-NOME-SEGURADO ,
            :RCAPS-VAL-RCAP ,
            :RCAPS-VAL-RCAP-PRINCIPAL ,
            :RCAPS-DATA-CADASTRAMENTO ,
            :RCAPS-DATA-MOVIMENTO ,
            :RCAPS-SIT-REGISTRO ,
            :RCAPS-COD-OPERACAO ,
            :RCAPS-COD-EMPRESA:VIND-NULL01 ,
            CURRENT TIMESTAMP ,
            :RCAPS-NUM-APOLICE:VIND-NULL02 ,
            :RCAPS-NUM-ENDOSSO:VIND-NULL03 ,
            :RCAPS-NUM-PARCELA:VIND-NULL04 ,
            :RCAPS-NUM-TITULO:VIND-NULL05 ,
            :RCAPS-CODIGO-PRODUTO:VIND-NULL06 ,
            :RCAPS-AGE-COBRANCA:VIND-NULL07 ,
            :RCAPS-RECUPERA:VIND-NULL08 ,
            :RCAPS-VLACRESCIMO:VIND-NULL09 ,
            :RCAPS-NUM-CERTIFICADO:VIND-NULL10)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RCAPS (COD_FONTE , NUM_RCAP , NUM_PROPOSTA , NOME_SEGURADO , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , COD_EMPRESA , TIMESTAMP , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_TITULO , CODIGO_PRODUTO , AGE_COBRANCA , RECUPERA , VLACRESCIMO , NUM_CERTIFICADO) VALUES ({FieldThreatment(this.RCAPS_COD_FONTE)} , {FieldThreatment(this.RCAPS_NUM_RCAP)} , {FieldThreatment(this.RCAPS_NUM_PROPOSTA)} , {FieldThreatment(this.RCAPS_NOME_SEGURADO)} , {FieldThreatment(this.RCAPS_VAL_RCAP)} , {FieldThreatment(this.RCAPS_VAL_RCAP_PRINCIPAL)} , {FieldThreatment(this.RCAPS_DATA_CADASTRAMENTO)} , {FieldThreatment(this.RCAPS_DATA_MOVIMENTO)} , {FieldThreatment(this.RCAPS_SIT_REGISTRO)} , {FieldThreatment(this.RCAPS_COD_OPERACAO)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.RCAPS_COD_EMPRESA))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.RCAPS_NUM_APOLICE))} ,  {FieldThreatment((this.VIND_NULL03?.ToInt() == -1 ? null : this.RCAPS_NUM_ENDOSSO))} ,  {FieldThreatment((this.VIND_NULL04?.ToInt() == -1 ? null : this.RCAPS_NUM_PARCELA))} ,  {FieldThreatment((this.VIND_NULL05?.ToInt() == -1 ? null : this.RCAPS_NUM_TITULO))} ,  {FieldThreatment((this.VIND_NULL06?.ToInt() == -1 ? null : this.RCAPS_CODIGO_PRODUTO))} ,  {FieldThreatment((this.VIND_NULL07?.ToInt() == -1 ? null : this.RCAPS_AGE_COBRANCA))} ,  {FieldThreatment((this.VIND_NULL08?.ToInt() == -1 ? null : this.RCAPS_RECUPERA))} ,  {FieldThreatment((this.VIND_NULL09?.ToInt() == -1 ? null : this.RCAPS_VLACRESCIMO))} ,  {FieldThreatment((this.VIND_NULL10?.ToInt() == -1 ? null : this.RCAPS_NUM_CERTIFICADO))})";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_NUM_PROPOSTA { get; set; }
        public string RCAPS_NOME_SEGURADO { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_VAL_RCAP_PRINCIPAL { get; set; }
        public string RCAPS_DATA_CADASTRAMENTO { get; set; }
        public string RCAPS_DATA_MOVIMENTO { get; set; }
        public string RCAPS_SIT_REGISTRO { get; set; }
        public string RCAPS_COD_OPERACAO { get; set; }
        public string RCAPS_COD_EMPRESA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string RCAPS_NUM_APOLICE { get; set; }
        public string VIND_NULL02 { get; set; }
        public string RCAPS_NUM_ENDOSSO { get; set; }
        public string VIND_NULL03 { get; set; }
        public string RCAPS_NUM_PARCELA { get; set; }
        public string VIND_NULL04 { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string VIND_NULL05 { get; set; }
        public string RCAPS_CODIGO_PRODUTO { get; set; }
        public string VIND_NULL06 { get; set; }
        public string RCAPS_AGE_COBRANCA { get; set; }
        public string VIND_NULL07 { get; set; }
        public string RCAPS_RECUPERA { get; set; }
        public string VIND_NULL08 { get; set; }
        public string RCAPS_VLACRESCIMO { get; set; }
        public string VIND_NULL09 { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }
        public string VIND_NULL10 { get; set; }

        public static void Execute(R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1 r1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1)
        {
            var ths = r1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1310_00_INSERT_RCAPS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}