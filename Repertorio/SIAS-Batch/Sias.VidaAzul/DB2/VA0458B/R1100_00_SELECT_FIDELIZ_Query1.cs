using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1100_00_SELECT_FIDELIZ_Query1 : QueryBasis<R1100_00_SELECT_FIDELIZ_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            OPCAOPAG,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB,
            VAL_PAGO
            INTO :PF-NUM-PROP-SIVPF,
            :PF-OPCAOPAG,
            :PF-AGECTADEB,
            :PF-OPRCTADEB,
            :PF-NUMCTADEB,
            :PF-DIGCTADEB,
            :PF-VAL-PAGO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NRCERTIF
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											OPCAOPAG
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
							,
											VAL_PAGO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string PF_NUM_PROP_SIVPF { get; set; }
        public string PF_OPCAOPAG { get; set; }
        public string PF_AGECTADEB { get; set; }
        public string PF_OPRCTADEB { get; set; }
        public string PF_NUMCTADEB { get; set; }
        public string PF_DIGCTADEB { get; set; }
        public string PF_VAL_PAGO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1100_00_SELECT_FIDELIZ_Query1 Execute(R1100_00_SELECT_FIDELIZ_Query1 r1100_00_SELECT_FIDELIZ_Query1)
        {
            var ths = r1100_00_SELECT_FIDELIZ_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_FIDELIZ_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_FIDELIZ_Query1();
            var i = 0;
            dta.PF_NUM_PROP_SIVPF = result[i++].Value?.ToString();
            dta.PF_OPCAOPAG = result[i++].Value?.ToString();
            dta.PF_AGECTADEB = result[i++].Value?.ToString();
            dta.PF_OPRCTADEB = result[i++].Value?.ToString();
            dta.PF_NUMCTADEB = result[i++].Value?.ToString();
            dta.PF_DIGCTADEB = result[i++].Value?.ToString();
            dta.PF_VAL_PAGO = result[i++].Value?.ToString();
            return dta;
        }

    }
}