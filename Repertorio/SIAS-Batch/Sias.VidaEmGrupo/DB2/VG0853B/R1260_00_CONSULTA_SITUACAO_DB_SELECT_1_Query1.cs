using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1 : QueryBasis<R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.SIT_REGISTRO
            INTO :V0HCTA-SITUACAO
            FROM SEGUROS.HIST_LANC_CTA T1
            WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND T1.NUM_PARCELA = :V0PROP-NRPARCEL
            AND T1.OCORR_HISTORICOCTA = (
            SELECT MAX( OCORR_HISTORICOCTA )
            FROM SEGUROS.HIST_LANC_CTA T2
            WHERE T2.NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND T2.NUM_PARCELA = :V0PROP-NRPARCEL
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.SIT_REGISTRO
											FROM SEGUROS.HIST_LANC_CTA T1
											WHERE T1.NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND T1.NUM_PARCELA = '{this.V0PROP_NRPARCEL}'
											AND T1.OCORR_HISTORICOCTA = (
											SELECT MAX( OCORR_HISTORICOCTA )
											FROM SEGUROS.HIST_LANC_CTA T2
											WHERE T2.NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND T2.NUM_PARCELA = '{this.V0PROP_NRPARCEL}'
											)";

            return query;
        }
        public string V0HCTA_SITUACAO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }

        public static R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1 Execute(R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1 r1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1)
        {
            var ths = r1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0HCTA_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}