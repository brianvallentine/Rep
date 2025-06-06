using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0781B
{
    public class M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCT_COBERTURA
            INTO
            :V0ENDOPARC-PCT-COBERTURA
            FROM SEGUROS.V0COBERAPOL
            WHERE
            NUM_APOLICE = :V1RELATORIOS-APOLICE AND
            NRENDOS = :V0ENDOPARC-NRENDOS AND
            NUM_ITEM = 0 AND
            RAMOFR = 93
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCT_COBERTURA
											FROM SEGUROS.V0COBERAPOL
											WHERE
											NUM_APOLICE = '{this.V1RELATORIOS_APOLICE}' AND
											NRENDOS = '{this.V0ENDOPARC_NRENDOS}' AND
											NUM_ITEM = 0 AND
											RAMOFR = 93";

            return query;
        }
        public string V0ENDOPARC_PCT_COBERTURA { get; set; }
        public string V1RELATORIOS_APOLICE { get; set; }
        public string V0ENDOPARC_NRENDOS { get; set; }

        public static M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1 Execute(M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1 m_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = m_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_100_BUSCA_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDOPARC_PCT_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}