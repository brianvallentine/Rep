using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class M_999_999_ROT_ERRO_DB_UPDATE_1_Update1 : QueryBasis<M_999_999_ROT_ERRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET SITUACAO = 'E'
				WHERE  NUM_APOLICE =  '{this.ENDO_NUM_APOLICE}'
				AND NRENDOS =  '{this.ENDO_NRENDOS}'";

            return query;
        }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static void Execute(M_999_999_ROT_ERRO_DB_UPDATE_1_Update1 m_999_999_ROT_ERRO_DB_UPDATE_1_Update1)
        {
            var ths = m_999_999_ROT_ERRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_999_999_ROT_ERRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}