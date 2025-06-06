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
    public class P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1 : QueryBasis<P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO FDRCAP.FC_HIST_TITULO
            (IDE_HIST_TITULO,
            COD_OPERACAO,
            DTH_REGISTRO,
            IDE_USUARIO,
            NUM_PLANO,
            NUM_SERIE,
            NUM_TITULO,
            COD_DETALHE,
            DES_MSG_ORIGEM,
            DES_MSG_DESTINO,
            IDE_CLIENTE,
            IDE_ENDERECO)
            VALUES (:FCHISTIT-IDE-HIST-TITULO,
            :FCHISTIT-COD-OPERACAO,
            CURRENT TIMESTAMP,
            :FCHISTIT-IDE-USUARIO,
            :FCHISTIT-NUM-PLANO,
            :FCHISTIT-NUM-SERIE,
            :FCHISTIT-NUM-TITULO,
            NULL,
            :FCHISTIT-DES-MSG-ORIGEM,
            :FCHISTIT-DES-MSG-DESTINO,
            :FCHISTIT-IDE-CLIENTE,
            NULL)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO FDRCAP.FC_HIST_TITULO (IDE_HIST_TITULO, COD_OPERACAO, DTH_REGISTRO, IDE_USUARIO, NUM_PLANO, NUM_SERIE, NUM_TITULO, COD_DETALHE, DES_MSG_ORIGEM, DES_MSG_DESTINO, IDE_CLIENTE, IDE_ENDERECO) VALUES ({FieldThreatment(this.FCHISTIT_IDE_HIST_TITULO)}, {FieldThreatment(this.FCHISTIT_COD_OPERACAO)}, CURRENT TIMESTAMP, {FieldThreatment(this.FCHISTIT_IDE_USUARIO)}, {FieldThreatment(this.FCHISTIT_NUM_PLANO)}, {FieldThreatment(this.FCHISTIT_NUM_SERIE)}, {FieldThreatment(this.FCHISTIT_NUM_TITULO)}, NULL, {FieldThreatment(this.FCHISTIT_DES_MSG_ORIGEM)}, {FieldThreatment(this.FCHISTIT_DES_MSG_DESTINO)}, {FieldThreatment(this.FCHISTIT_IDE_CLIENTE)}, NULL)";

            return query;
        }
        public string FCHISTIT_IDE_HIST_TITULO { get; set; }
        public string FCHISTIT_COD_OPERACAO { get; set; }
        public string FCHISTIT_IDE_USUARIO { get; set; }
        public string FCHISTIT_NUM_PLANO { get; set; }
        public string FCHISTIT_NUM_SERIE { get; set; }
        public string FCHISTIT_NUM_TITULO { get; set; }
        public string FCHISTIT_DES_MSG_ORIGEM { get; set; }
        public string FCHISTIT_DES_MSG_DESTINO { get; set; }
        public string FCHISTIT_IDE_CLIENTE { get; set; }

        public static void Execute(P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1 p070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1)
        {
            var ths = p070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P070_GRAVA_HIST_TITULO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}