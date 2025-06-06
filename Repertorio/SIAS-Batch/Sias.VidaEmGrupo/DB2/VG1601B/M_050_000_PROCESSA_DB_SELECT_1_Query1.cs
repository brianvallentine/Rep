using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_050_000_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_050_000_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_OPERACAO
            INTO
            :MOVIMVGA-COD-OPERACAO
            FROM
            SEGUROS.MOVIMENTO_VGAP
            WHERE
            NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = :SEGURVGA-TIPO-SEGURADO
            AND COD_OPERACAO BETWEEN 400 AND 499
            AND DATA_INCLUSAO IS NULL
            AND DATA_AVERBACAO IS NOT NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_OPERACAO
											FROM
											SEGUROS.MOVIMENTO_VGAP
											WHERE
											NUM_CERTIFICADO = '{this.SEGURVGA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '{this.SEGURVGA_TIPO_SEGURADO}'
											AND COD_OPERACAO BETWEEN 400 AND 499
											AND DATA_INCLUSAO IS NULL
											AND DATA_AVERBACAO IS NOT NULL";

            return query;
        }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string SEGURVGA_TIPO_SEGURADO { get; set; }

        public static M_050_000_PROCESSA_DB_SELECT_1_Query1 Execute(M_050_000_PROCESSA_DB_SELECT_1_Query1 m_050_000_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_050_000_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_050_000_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_050_000_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}