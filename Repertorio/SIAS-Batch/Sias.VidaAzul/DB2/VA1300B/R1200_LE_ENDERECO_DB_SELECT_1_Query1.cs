using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1200_LE_ENDERECO_DB_SELECT_1_Query1 : QueryBasis<R1200_LE_ENDERECO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT X.NOM_LOGRADOURO,
            X.DES_NUM_IMOVEL,
            X.DES_COMPL_ENDERECO,
            X.NOM_BAIRRO,
            X.NOM_CIDADE,
            X.COD_CEP,
            X.COD_UF
            INTO :OD007-NOM-LOGRADOURO,
            :OD007-DES-NUM-IMOVEL,
            :OD007-DES-COMPL-ENDERECO,
            :OD007-NOM-BAIRRO,
            :OD007-NOM-CIDADE,
            :OD007-COD-CEP,
            :OD007-COD-UF
            FROM SEGUROS.GE_LEG_PESS_EVENTO E,
            ODS.OD_PESSOA_ENDERECO X
            WHERE E.NUM_OCORR_MOVTO = :GE368-NUM-OCORR-MOVTO
            AND E.IND_ENTIDADE = 1
            AND X.NUM_PESSOA = E.NUM_PESSOA
            AND X.SEQ_ENDERECO = E.SEQ_ENTIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT X.NOM_LOGRADOURO
							,
											X.DES_NUM_IMOVEL
							,
											X.DES_COMPL_ENDERECO
							,
											X.NOM_BAIRRO
							,
											X.NOM_CIDADE
							,
											X.COD_CEP
							,
											X.COD_UF
											FROM SEGUROS.GE_LEG_PESS_EVENTO E
							,
											ODS.OD_PESSOA_ENDERECO X
											WHERE E.NUM_OCORR_MOVTO = '{this.GE368_NUM_OCORR_MOVTO}'
											AND E.IND_ENTIDADE = 1
											AND X.NUM_PESSOA = E.NUM_PESSOA
											AND X.SEQ_ENDERECO = E.SEQ_ENTIDADE";

            return query;
        }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string OD007_COD_UF { get; set; }
        public string GE368_NUM_OCORR_MOVTO { get; set; }

        public static R1200_LE_ENDERECO_DB_SELECT_1_Query1 Execute(R1200_LE_ENDERECO_DB_SELECT_1_Query1 r1200_LE_ENDERECO_DB_SELECT_1_Query1)
        {
            var ths = r1200_LE_ENDERECO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_LE_ENDERECO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_LE_ENDERECO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD007_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.OD007_DES_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.OD007_DES_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.OD007_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.OD007_NOM_CIDADE = result[i++].Value?.ToString();
            dta.OD007_COD_CEP = result[i++].Value?.ToString();
            dta.OD007_COD_UF = result[i++].Value?.ToString();
            return dta;
        }

    }
}