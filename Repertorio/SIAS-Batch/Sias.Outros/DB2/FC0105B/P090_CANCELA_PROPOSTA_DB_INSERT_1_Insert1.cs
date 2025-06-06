using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC0105B
{
    public class P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1 : QueryBasis<P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO FDRCAP.FC_HIST_PROPOSTA
            ( NUM_PLANO
            , NUM_PROPOSTA
            , NUM_NSA
            , DTH_REGISTRO
            , HRS_REGISTRO
            , IDE_USUARIO
            , COD_OPERACAO
            , DES_MSG_ORIGEM
            , DES_MSG_DESTINO)
            VALUES( :FCHISPRO-NUM-PLANO
            , :FCHISPRO-NUM-PROPOSTA
            , :FCHISPRO-NUM-NSA
            , CURRENT DATE
            , CURRENT TIME
            , :FCHISPRO-IDE-USUARIO
            , :FCHISPRO-COD-OPERACAO
            , :FCHISPRO-DES-MSG-ORIGEM
            , :FCHISPRO-DES-MSG-DESTINO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO FDRCAP.FC_HIST_PROPOSTA ( NUM_PLANO , NUM_PROPOSTA , NUM_NSA , DTH_REGISTRO , HRS_REGISTRO , IDE_USUARIO , COD_OPERACAO , DES_MSG_ORIGEM , DES_MSG_DESTINO) VALUES( {FieldThreatment(this.FCHISPRO_NUM_PLANO)} , {FieldThreatment(this.FCHISPRO_NUM_PROPOSTA)} , {FieldThreatment(this.FCHISPRO_NUM_NSA)} , CURRENT DATE , CURRENT TIME , {FieldThreatment(this.FCHISPRO_IDE_USUARIO)} , {FieldThreatment(this.FCHISPRO_COD_OPERACAO)} , {FieldThreatment(this.FCHISPRO_DES_MSG_ORIGEM)} , {FieldThreatment(this.FCHISPRO_DES_MSG_DESTINO)})";

            return query;
        }
        public string FCHISPRO_NUM_PLANO { get; set; }
        public string FCHISPRO_NUM_PROPOSTA { get; set; }
        public string FCHISPRO_NUM_NSA { get; set; }
        public string FCHISPRO_IDE_USUARIO { get; set; }
        public string FCHISPRO_COD_OPERACAO { get; set; }
        public string FCHISPRO_DES_MSG_ORIGEM { get; set; }
        public string FCHISPRO_DES_MSG_DESTINO { get; set; }

        public static void Execute(P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1 p090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1)
        {
            var ths = p090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P090_CANCELA_PROPOSTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}