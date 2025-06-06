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
    public class R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 : QueryBasis<R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PARCELAS_VIDAZUL
            SELECT
            NUM_CERTIFICADO ,
            :PARCEVID-NUM-PARCELA1 NUM_PARCELA ,
            :PROPOVA-DTPROXVEN DATA_VENCIMENTO,
            :PLAVAVGA-PRMVG PREMIO_VG,
            :PLAVAVGA-PRMAP PREMIO_AP,
            VLMULTA ,
            :OPCPAGVI-OPCAO-PAGAMENTO OPCAO_PAGAMENTO,
            ' ' SIT_REGISTRO,
            1 OCORR_HISTORICO,
            CURRENT TIMESTAMP
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :PARCEVID-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PARCELAS_VIDAZUL SELECT NUM_CERTIFICADO , {FieldThreatment(this.PARCEVID_NUM_PARCELA1)} NUM_PARCELA , {FieldThreatment(this.PROPOVA_DTPROXVEN)} DATA_VENCIMENTO, {FieldThreatment(this.PLAVAVGA_PRMVG)} PREMIO_VG, {FieldThreatment(this.PLAVAVGA_PRMAP)} PREMIO_AP, VLMULTA , {FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)} OPCAO_PAGAMENTO, ' ' SIT_REGISTRO, 1 OCORR_HISTORICO, CURRENT TIMESTAMP FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)} AND NUM_PARCELA = {FieldThreatment(this.PARCEVID_NUM_PARCELA)}";

            return query;
        }
        public string PARCEVID_NUM_PARCELA1 { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PLAVAVGA_PRMVG { get; set; }
        public string PLAVAVGA_PRMAP { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PARCEVID_NUM_PARCELA { get; set; }

        public static void Execute(R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 r1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1)
        {
            var ths = r1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}