using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1 : QueryBasis<M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1>
    {

        private VE0505B_CCOMIS CurrentOf { get; set; }

        public M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1(VE0505B_CCOMIS currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0COMISSAO
            WHERE CURRENT OF CCOMIS
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0COMISSAO
				WHERE
				(
					DATSEL = '9999-12-31' AND TIPCOM IN ( 'G', 'H', 'I' ) AND NUMREC = 0 AND VLCOMIS > 0
				)
				AND NRPARCEL {FieldThreatment(CurrentOf.V0COMI_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1 m_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1)
        {
            var ths = m_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0200_APROPRIA_FUNDO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}