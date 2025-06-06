using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1 : QueryBasis<R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SEGURADOSVGAP_HIST
            SELECT
            NUM_APOLICE,
            :SUBGVGAP-COD-SUBGRUPO COD_SUBGRUPO,
            NUM_ITEM,
            202 COD_OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO DATA_OPERACAO,
            :WHOST-HORA-OPERACAO HORA_OPERACAO,
            :SISTEMAS-DATA-MOV-ABERTO DATA_MOVIMENTO,
            :SEGURVGA-OCORR-HISTORICO1 OCORR_HISTORICO,
            COD_SUBGRUPO_TRANS,
            :SISTEMAS-DATA-MOV-ABERTO DATA_REFERENCIA,
            'VA0123B' COD_USUARIO,
            COD_EMPRESA, COD_MOEDA_IMP, COD_MOEDA_PRM
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SEGURADOSVGAP_HIST SELECT NUM_APOLICE, {FieldThreatment(this.SUBGVGAP_COD_SUBGRUPO)} COD_SUBGRUPO, NUM_ITEM, 202 COD_OPERACAO, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} DATA_OPERACAO, {FieldThreatment(this.WHOST_HORA_OPERACAO)} HORA_OPERACAO, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} DATA_MOVIMENTO, {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO1)} OCORR_HISTORICO, COD_SUBGRUPO_TRANS, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} DATA_REFERENCIA, 'VA0123B' COD_USUARIO, COD_EMPRESA, COD_MOEDA_IMP, COD_MOEDA_PRM FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = {FieldThreatment(this.PROPOVA_NUM_APOLICE)} AND NUM_ITEM = {FieldThreatment(this.SEGURVGA_NUM_ITEM)} AND OCORR_HISTORICO = {FieldThreatment(this.SEGURVGA_OCORR_HISTORICO)}";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_HORA_OPERACAO { get; set; }
        public string SEGURVGA_OCORR_HISTORICO1 { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }

        public static void Execute(R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1 r1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1)
        {
            var ths = r1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}