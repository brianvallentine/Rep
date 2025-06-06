using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1110B
{
    public class P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1 : QueryBasis<P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GEPESSOA.COD_PESSOA
            ,VALUE(GEPESSOA.NOM_PESSOA, ' ' )
            INTO :GEPESSOA-COD-PESSOA
            ,:GEPESSOA-NOM-PESSOA
            FROM SEGUROS.EF_SEGURADO_OBJETO EF079
            ,SEGUROS.GE_PESSOA GEPESSOA
            WHERE EF079.NUM_CONTRATO_SEGUR =
            :EF150-NUM-CONTRATO-SEGUR
            AND EF079.COD_PESSOA_CONTRTE = GEPESSOA.COD_PESSOA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT GEPESSOA.COD_PESSOA
											,VALUE(GEPESSOA.NOM_PESSOA
							, ' ' )
											FROM SEGUROS.EF_SEGURADO_OBJETO EF079
											,SEGUROS.GE_PESSOA GEPESSOA
											WHERE EF079.NUM_CONTRATO_SEGUR =
											'{this.EF150_NUM_CONTRATO_SEGUR}'
											AND EF079.COD_PESSOA_CONTRTE = GEPESSOA.COD_PESSOA
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GEPESSOA_COD_PESSOA { get; set; }
        public string GEPESSOA_NOM_PESSOA { get; set; }
        public string EF150_NUM_CONTRATO_SEGUR { get; set; }

        public static P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1 Execute(P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1 p2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1)
        {
            var ths = p2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2410_BUSCA_GEPESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEPESSOA_COD_PESSOA = result[i++].Value?.ToString();
            dta.GEPESSOA_NOM_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}