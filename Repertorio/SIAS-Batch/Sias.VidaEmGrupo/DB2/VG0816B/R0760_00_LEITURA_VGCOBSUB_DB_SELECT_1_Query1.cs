using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 : QueryBasis<R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX
            INTO :VGCOBSUB-IMP-SEGURADA-IX
            FROM SEGUROS.VG_COBERTURAS_SUBG
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            AND COD_COBERTURA = :VGCOBSUB-COD-COBERTURA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
											FROM SEGUROS.VG_COBERTURAS_SUBG
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											AND COD_COBERTURA = '{this.VGCOBSUB_COD_COBERTURA}'";

            return query;
        }
        public string VGCOBSUB_IMP_SEGURADA_IX { get; set; }
        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 Execute(R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 r0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1)
        {
            var ths = r0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOBSUB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}