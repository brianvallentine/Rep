using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 : QueryBasis<M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXA_VG
            INTO :TAXA-VG
            FROM SEGUROS.FAIXA_ETARIA
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND COD_SUBGRUPO = :WS-COD-SUBGRUPO
            AND IDADE_INICIAL >= :WS-IDADE
            AND IDADE_FINAL <= :WS-IDADE
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_VG
											FROM SEGUROS.FAIXA_ETARIA
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.WS_COD_SUBGRUPO}'
											AND IDADE_INICIAL >= '{this.WS_IDADE}'
											AND IDADE_FINAL <= '{this.WS_IDADE}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )";

            return query;
        }
        public string TAXA_VG { get; set; }
        public string WS_COD_SUBGRUPO { get; set; }
        public string WS_NUM_APOLICE { get; set; }
        public string WS_IDADE { get; set; }

        public static M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 Execute(M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1)
        {
            var ths = m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.TAXA_VG = result[i++].Value?.ToString();
            return dta;
        }

    }
}