using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1 : QueryBasis<R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDERECOS
				SET ENDERECO =  '{this.ENDERECO_ENDERECO}',
				BAIRRO =  '{this.ENDERECO_BAIRRO}',
				CIDADE =  '{this.ENDERECO_CIDADE}'
				WHERE  COD_CLIENTE =  '{this.CLIENTES_COD_CLIENTE}'
				AND COD_ENDERECO =  '{this.ENDERECO_COD_ENDERECO}'";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static void Execute(R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1 r1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1)
        {
            var ths = r1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_PROCESSA_COMPL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}