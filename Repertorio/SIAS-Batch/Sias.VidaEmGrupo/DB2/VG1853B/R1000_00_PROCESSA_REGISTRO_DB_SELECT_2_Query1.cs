using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            SIT_REGISTRO,
            TIPO_FATURAMENTO,
            FORMA_FATURAMENTO
            INTO :V0SUBG-NUM-APOLICE,
            :V0SUBG-SIT-REGISTRO,
            :V0SUBG-TIPO-FATURA,
            :V0SUBG-FORMA-FATURA
            FROM SEGUROS.V0SUBGRUPO
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            AND NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND COD_SUBGRUPO = :V0PROP-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											SIT_REGISTRO
							,
											TIPO_FATURAMENTO
							,
											FORMA_FATURAMENTO
											FROM SEGUROS.V0SUBGRUPO
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'
											AND NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'";

            return query;
        }
        public string V0SUBG_NUM_APOLICE { get; set; }
        public string V0SUBG_SIT_REGISTRO { get; set; }
        public string V0SUBG_TIPO_FATURA { get; set; }
        public string V0SUBG_FORMA_FATURA { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_CODSUBES { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0SUBG_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0SUBG_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.V0SUBG_TIPO_FATURA = result[i++].Value?.ToString();
            dta.V0SUBG_FORMA_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}