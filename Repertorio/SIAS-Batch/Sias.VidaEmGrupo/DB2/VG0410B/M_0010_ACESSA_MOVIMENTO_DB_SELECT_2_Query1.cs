using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0410B
{
    public class M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1 : QueryBasis<M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT SIT_REGISTRO
            INTO :SEGUVG-SITUACAO
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_CERTIFICADO = :MOVTO-NUM-CERTIFIC
            AND TIPO_SEGURADO = '1'
            AND SIT_REGISTRO IN ( '0' , '1' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.MOVTO_NUM_CERTIFIC}'
											AND TIPO_SEGURADO = '1'
											AND SIT_REGISTRO IN ( '0' 
							, '1' )
											WITH UR";

            return query;
        }
        public string SEGUVG_SITUACAO { get; set; }
        public string MOVTO_NUM_CERTIFIC { get; set; }

        public static M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1 Execute(M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1 m_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1)
        {
            var ths = m_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0010_ACESSA_MOVIMENTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.SEGUVG_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}