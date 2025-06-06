using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0130B
{
    public class M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            NUM_CERTIFICADO,
            TIPO_SEGURADO,
            DATA_INCLUSAO
            INTO
            :MNUM-APOLICE,
            :MNUM-CERTIFICADO,
            :MTIPO-SEGURADO,
            :MDATA-INCLUSAO:WDATA-INCLUSAO
            FROM
            SEGUROS.V1MOVIMENTO
            WHERE
            NUM_CERTIFICADO = :SNUM-CERTIFICADO AND
            COD_OPERACAO = 0891 AND
            TIPO_SEGURADO = :STIPO-SEGURADO AND
            DATA_INCLUSAO IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											NUM_CERTIFICADO
							,
											TIPO_SEGURADO
							,
											DATA_INCLUSAO
											FROM
											SEGUROS.V1MOVIMENTO
											WHERE
											NUM_CERTIFICADO = '{this.SNUM_CERTIFICADO}' AND
											COD_OPERACAO = 0891 AND
											TIPO_SEGURADO = '{this.STIPO_SEGURADO}' AND
											DATA_INCLUSAO IS NULL";

            return query;
        }
        public string MNUM_APOLICE { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string MDATA_INCLUSAO { get; set; }
        public string WDATA_INCLUSAO { get; set; }
        public string SNUM_CERTIFICADO { get; set; }
        public string STIPO_SEGURADO { get; set; }

        public static M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1 Execute(M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1 m_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = m_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_280_000_ACESSA_V1MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MNUM_APOLICE = result[i++].Value?.ToString();
            dta.MNUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MTIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MDATA_INCLUSAO = result[i++].Value?.ToString();
            dta.WDATA_INCLUSAO = string.IsNullOrWhiteSpace(dta.MDATA_INCLUSAO) ? "-1" : "0";
            return dta;
        }

    }
}