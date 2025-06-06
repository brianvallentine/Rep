using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0020B
{
    public class M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 : QueryBasis<M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA + :V0CAR-CARENCIA MONTHS
            INTO :V0CAR-DTTERVIG
            FROM SEGUROS.V0MOVIMENTO
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND COD_FONTE = :MCOD-FONTE
            AND NUM_PROPOSTA = :MNUM-PROPOSTA
            AND TIPO_SEGURADO = :MTIPO-SEGURADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA + {this.V0CAR_CARENCIA} MONTHS
											FROM SEGUROS.V0MOVIMENTO
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND COD_FONTE = '{this.MCOD_FONTE}'
											AND NUM_PROPOSTA = '{this.MNUM_PROPOSTA}'
											AND TIPO_SEGURADO = '{this.MTIPO_SEGURADO}'
											WITH UR";

            return query;
        }
        public string V0CAR_DTTERVIG { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string V0CAR_CARENCIA { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_FONTE { get; set; }

        public static M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 Execute(M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 m_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1)
        {
            var ths = m_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CAR_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}