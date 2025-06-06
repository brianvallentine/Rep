using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0020_00_PROCESSA_DB_SELECT_5_Query1 : QueryBasis<R0020_00_PROCESSA_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIGEM_PROPOSTA,
            AGECTADEB,
            OPRCTADEB,
            NUMCTADEB,
            DIGCTADEB
            INTO :WHOST-ORIGEM-PROPOSTA,
            :WHOST-AGECTADEB-FID,
            :WHOST-OPRCTADEB-FID,
            :WHOST-NUMCTADEB-FID,
            :WHOST-DIGCTADEB-FID
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :V0HCTA-NRCERTIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIGEM_PROPOSTA
							,
											AGECTADEB
							,
											OPRCTADEB
							,
											NUMCTADEB
							,
											DIGCTADEB
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.V0HCTA_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string WHOST_ORIGEM_PROPOSTA { get; set; }
        public string WHOST_AGECTADEB_FID { get; set; }
        public string WHOST_OPRCTADEB_FID { get; set; }
        public string WHOST_NUMCTADEB_FID { get; set; }
        public string WHOST_DIGCTADEB_FID { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static R0020_00_PROCESSA_DB_SELECT_5_Query1 Execute(R0020_00_PROCESSA_DB_SELECT_5_Query1 r0020_00_PROCESSA_DB_SELECT_5_Query1)
        {
            var ths = r0020_00_PROCESSA_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_00_PROCESSA_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_00_PROCESSA_DB_SELECT_5_Query1();
            var i = 0;
            dta.WHOST_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.WHOST_AGECTADEB_FID = result[i++].Value?.ToString();
            dta.WHOST_OPRCTADEB_FID = result[i++].Value?.ToString();
            dta.WHOST_NUMCTADEB_FID = result[i++].Value?.ToString();
            dta.WHOST_DIGCTADEB_FID = result[i++].Value?.ToString();
            return dta;
        }

    }
}