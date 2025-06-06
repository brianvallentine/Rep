using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1 : QueryBasis<R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.V0APOLCOB VALUES
            ( :V0APOLC-COD-EMPRESA,
            :V0APOLC-FONTE,
            :V0APOLC-NUM-APOLICE,
            :V0APOLC-NRENDOS,
            :V0APOLC-CODPRODU,
            :V0APOLC-NUM-MATRICULA,
            :V0APOLC-TIPO-COBRANCA,
            :V0APOLC-AGECOBR,
            :V0APOLC-COD-AGENCIA,
            :V0APOLC-OPER-CONTA,
            :V0APOLC-NUM-CONTA,
            :V0APOLC-DIG-CONTA,
            :V0APOLC-COD-AGENCIA-DEB,
            :V0APOLC-OPER-CONTA-DEB,
            :V0APOLC-NUM-CONTA-DEB,
            :V0APOLC-DIG-CONTA-DEB,
            :V0APOLC-NUM-CARTAO,
            :V0APOLC-DIA-DEBITO,
            :V0APOLC-NRCERTIF-AUTO,
            CURRENT TIMESTAMP,
            :V0APOLC-MARGEM-COMERCIAL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCOB VALUES ( {FieldThreatment(this.V0APOLC_COD_EMPRESA)}, {FieldThreatment(this.V0APOLC_FONTE)}, {FieldThreatment(this.V0APOLC_NUM_APOLICE)}, {FieldThreatment(this.V0APOLC_NRENDOS)}, {FieldThreatment(this.V0APOLC_CODPRODU)}, {FieldThreatment(this.V0APOLC_NUM_MATRICULA)}, {FieldThreatment(this.V0APOLC_TIPO_COBRANCA)}, {FieldThreatment(this.V0APOLC_AGECOBR)}, {FieldThreatment(this.V0APOLC_COD_AGENCIA)}, {FieldThreatment(this.V0APOLC_OPER_CONTA)}, {FieldThreatment(this.V0APOLC_NUM_CONTA)}, {FieldThreatment(this.V0APOLC_DIG_CONTA)}, {FieldThreatment(this.V0APOLC_COD_AGENCIA_DEB)}, {FieldThreatment(this.V0APOLC_OPER_CONTA_DEB)}, {FieldThreatment(this.V0APOLC_NUM_CONTA_DEB)}, {FieldThreatment(this.V0APOLC_DIG_CONTA_DEB)}, {FieldThreatment(this.V0APOLC_NUM_CARTAO)}, {FieldThreatment(this.V0APOLC_DIA_DEBITO)}, {FieldThreatment(this.V0APOLC_NRCERTIF_AUTO)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0APOLC_MARGEM_COMERCIAL)})";

            return query;
        }
        public string V0APOLC_COD_EMPRESA { get; set; }
        public string V0APOLC_FONTE { get; set; }
        public string V0APOLC_NUM_APOLICE { get; set; }
        public string V0APOLC_NRENDOS { get; set; }
        public string V0APOLC_CODPRODU { get; set; }
        public string V0APOLC_NUM_MATRICULA { get; set; }
        public string V0APOLC_TIPO_COBRANCA { get; set; }
        public string V0APOLC_AGECOBR { get; set; }
        public string V0APOLC_COD_AGENCIA { get; set; }
        public string V0APOLC_OPER_CONTA { get; set; }
        public string V0APOLC_NUM_CONTA { get; set; }
        public string V0APOLC_DIG_CONTA { get; set; }
        public string V0APOLC_COD_AGENCIA_DEB { get; set; }
        public string V0APOLC_OPER_CONTA_DEB { get; set; }
        public string V0APOLC_NUM_CONTA_DEB { get; set; }
        public string V0APOLC_DIG_CONTA_DEB { get; set; }
        public string V0APOLC_NUM_CARTAO { get; set; }
        public string V0APOLC_DIA_DEBITO { get; set; }
        public string V0APOLC_NRCERTIF_AUTO { get; set; }
        public string V0APOLC_MARGEM_COMERCIAL { get; set; }

        public static void Execute(R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1 r0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1)
        {
            var ths = r0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}