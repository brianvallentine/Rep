using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1 : QueryBasis<M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO,
            NUM_ITEM,
            SIT_REGISTRO,
            VALUE(DATA_INIVIGENCIA, '0001-01-01' )
            INTO :SEGURVGA-OCORR-HISTORICO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-SIT-REGISTRO,
            :SEGURVGA-DATA-ADMISSAO
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
							,
											NUM_ITEM
							,
											SIT_REGISTRO
							,
											VALUE(DATA_INIVIGENCIA
							, '0001-01-01' )
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string SEGURVGA_DATA_ADMISSAO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1 Execute(M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1 m_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1)
        {
            var ths = m_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_ADMISSAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}